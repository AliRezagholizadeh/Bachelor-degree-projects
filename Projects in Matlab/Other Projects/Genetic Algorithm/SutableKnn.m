function n=SutableKnn(data)
n=0;
m=size(data,2);
for i=m:-1:1
    n=n+data(1,i)*(10^(m-i));
end
end