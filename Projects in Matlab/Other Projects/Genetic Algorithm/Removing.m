function result=Removing(Matrix,SubMat)
result=[];
flag=zeros(size(Matrix,1),1);
    for i=1:size(SubMat,1)
        for j=1:size(Matrix,1)
            if Matrix(j,:)==SubMat(i,:)
                flag(j,1)=1;
            end
        end
    end
    flag;
    a=(flag==0);
    b=(flag==1);
    flag(a)=1;
    flag(b)=0;
    for i=1:size(flag,1)
        if flag(i,1)==1
            result=[result;Matrix(i,:)];
        end
    end
    result;
end