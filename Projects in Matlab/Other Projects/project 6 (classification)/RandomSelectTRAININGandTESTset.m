function [Train,Test]=RandomSelectTRAININGandTESTset(set,label,NumOfTrain)
numberOfset=size(set,1); %point are stored in form of column in set(assemble of point in any set)
flag=zeros(numberOfset,1);  %we want to use flag as boolean column vector 
i=1;
    while i <= NumOfTrain
     r1=randi([1 size(set,1)],1);
     if flag(r1,1)==0 & set(r1,end)==label
         flag(r1,1)=1;
         i=i+1;
     end
    end
    Train=zeros(NumOfTrain,size(set,2));
    Test=zeros((numberOfset/2)-NumOfTrain,size(set,2));   %BA FARZE INKE TEDAD SAMPLE HAYE HAR CLASS ARE EQUAL 
    j=1;
    l=1;
    for i=1:numberOfset
        if flag(i,1)==1
            Train(j,:)=set(i,:);
            j=j+1;
        end
        if flag(i,1)==0 & set(i,end)==label
            Test(l,:)=set(i,:);
            l=l+1;
        end
    end
end