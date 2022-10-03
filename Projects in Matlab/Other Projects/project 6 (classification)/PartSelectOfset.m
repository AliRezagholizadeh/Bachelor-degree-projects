function [Train,Test]=PartSelectOfset(set,ClassLabel,NumOfTrain,Part)
%Train and Test have type of class in end column
numberInset=size(set,1);
Train=zeros(NumOfTrain,size(set,2));
    Test=zeros((numberInset/2)-NumOfTrain,size(set,2));   %BA FARZE INKE TEDAD SAMPLE HAYE HAR CLASS ARE EQUAL 
    j=1;
    l=1;
    for i=1:numberInset
        if j>=((Part-1)*NumOfTrain+1) & j<=(Part)*NumOfTrain
            if set(i,end)==ClassLabel
             Train(j,:)=set(i,:);
             j=j+1;
            end
        else
            if set(i,end)==ClassLabel
                Test(l,:)=set(i,:);
                l=l+1;
            end
        end
    end
end