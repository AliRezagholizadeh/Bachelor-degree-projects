 function improvedIm=FilterFunction(signal,type,percentage)
N=size(signal,1); 
   
  if mod(N,2)==0
      N=N-1;
  end
   H=zeros(N);
  
  u=-floor(N/2):floor(N/2);
  v=-floor(N/2):floor(N/2);
  [U,V]=meshgrid(u,v);

  
   switch type
       case 'lowpass'
           Dist=sqrt(U.^2+V.^2);
              J=find(Dist<percentage*N/2);
           H(J)=1;
       case 'highpass'  
           Dist=sqrt(U.^2+V.^2);
           J=find(Dist<percentage*N/2);
           H=ones(size(H));
           H(J)=0;
       case 'bandpass'
           Dist=sqrt(U.^2+V.^2);
           J1=find(Dist<percentage(2)*N/2);
            J2=find(Dist<percentage(1)*N/2);
           H(J1)=1;
           H(J2)=0;
   end
   
   H=imresize(H,size(signal));
   
figure
imshow(H)
improvedIm=H.*signal;
 end