function FTedIm=FourierTransform(image)
%image is N*N matrix 
F=zeros(uint8(size(image,1)));
N=size(image,1);
w=exp((-1*complex(0,1)*2*pi)/N);

for i=1:N
    for j=1:N
        if i==1 || j==1
            F(i,j)=1;
        else
            F(i,j)=w^((i-1)*(j-1));
        end
    end
end

FTedIm=F*image*F;

end