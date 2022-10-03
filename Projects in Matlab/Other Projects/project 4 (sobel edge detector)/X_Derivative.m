function result=X_Derivative(image)

image=double(image);
result=zeros(size(image,1),size(image,2));

window=[1  0 -1;
        2  0 -2;
        1  0 -1];

row=size(image,1);
column=size(image,2);
rBound=floor(size(window,1)/2);             %for starting from middle of window
cBound=rBound;

for i=1+rBound : row-rBound
    a=i-rBound;
    for j=1+cBound : column-cBound
        b=j-cBound;
        sum=0;
        for k=a : (i+rBound)
            for l=b : (j+cBound)
                sum=sum+window(k-a+1,l-b+1)*image(k,l);   
            end
        end
       
            result(i,j)=sum;
            
    end
end


end