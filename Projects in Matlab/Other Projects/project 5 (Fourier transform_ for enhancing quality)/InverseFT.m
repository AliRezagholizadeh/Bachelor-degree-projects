function ChDomSignal=InverseFT(signal)
Fs=zeros(size(signal,1));
N=size(signal,1);
w=exp((-1*complex(0,1)*2*pi)/N);

for i=1:N
    for j=1:N
        Fs(i,j)=w^(-1*(i-1)*(j-1));
    end
end

ChDomSignal=(1/(N^2))*(Fs*signal*Fs);
end