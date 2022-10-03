function Cov=Covariancefunc(matrix)
%It calculate covariance betwen each column (dimention is number of column) 
[m,n]=size(matrix);
matrix=double(matrix);
Cov=zeros(n,n);
for i=1:n-1
    for j=i+1:n
     a=cov(transpose(matrix(:,i)),transpose(matrix(:,j)));
     Cov(i,j)=a(1,2);
     Cov(j,i)=a(2,1);
     Cov(i,i)=a(1,1);
     Cov(j,j)=a(2,2);
    end
end
end