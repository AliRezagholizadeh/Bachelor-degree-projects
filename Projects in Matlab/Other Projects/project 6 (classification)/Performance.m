function result=Performance(ClassifiedSet,Test)
%ClassifiedSet is same size of Test.
correct=0;
error=0;
    for i=1:size(Test,1)
        if ClassifiedSet(i,1:end-1) == Test(i,1:end-1) 
            
            if ClassifiedSet(i,end) == Test(i,end)
             correct=correct+1;
            end
        else
            error=error+1;
        end
    end
all=size(Test,1);
result=(correct/all);
error;
correct;
end
