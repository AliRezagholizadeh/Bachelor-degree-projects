function EnhancedIm=MedianFilter(image,WindowSize)
%-construct window of (WindowSize*WindowSize)
image=double(image);
EnhancedIm=zeros(size(image,1),size(image,2));
window=(zeros(WindowSize,WindowSize));

row=size(image,1);
column=size(image,2);
rBound=floor(WindowSize/2);             %for starting from middle of window
cBound=rBound;


for i=1+rBound : row-rBound
    a=i-rBound;
    for j=1+cBound : column-cBound
        b=j-cBound;
        for k=a : (i+rBound)
            for l=b : (j+cBound)
                window(k-a+1,l-b+1)=image(k,l);   
            end
        end
        EnhancedIm(i,j)=Median(window);
    end
end
EnhancedIm=uint8(EnhancedIm);
end

function m=Median(window)
    concat=window(1,:);
    if  size(window,1)>1
        for i=2:size(window,1)
             concat=[concat,window(i,:)];              %for use of sort function
        end
    end
   
    s=sort(concat);
    m=s(1,floor(size(s,2)/2));
end