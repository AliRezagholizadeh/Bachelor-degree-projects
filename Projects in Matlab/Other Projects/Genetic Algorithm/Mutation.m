function result=Mutation(parent,Alphabet)
%parent is matrix ; Alphabet is 1*n matrix
result=[];
i=1;
    while i <= size(parent,1)
        CurrParent=parent(i,1:end-1);
        index=randi([1 size(CurrParent,2)],1);
            flag=(Alphabet==CurrParent(1,index));
            a=(flag==0);
            b=(flag==1);
            flag(a)=1;
            flag(b)=0;
            NewRange=Alphabet (flag);
            
        ReplacedNum=NewRange(1,randi(size(NewRange,2),1));
        if index ==1  & ReplacedNum==0
            CurrParent(1,index)=NewRange(1,randi(size(NewRange,2),1));
        else
             CurrParent(1,index)=ReplacedNum;
        end
        %+++++++++++++++++++++++++++++++++++++++++++++++++++
            %below if' for My KNN Sample limite ; my training set has 400
            %point .
        if SutableKnn(CurrParent) <= 400     
           result=[result;CurrParent];
           i=i+1;
      
        end
        %+++++++++++++++++++++++++++++++++++++++++++++++++++++++
        
    end
    result=Performance(result);
    
end