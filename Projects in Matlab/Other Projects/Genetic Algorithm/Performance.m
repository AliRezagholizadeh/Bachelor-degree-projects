function result=Performance(Data)
% This function perform Performance in Classification of KNN by diferent
% K .
TestSet=[];
load('sampleOfData1.mat');
result=[];
p=[];
all=size(TestSet,1);
    for i=1:size(Data,1)
        K=SutableKnn(Data(i,:));
        ClassifiedSet=K_NearestN(TrainSet,TestSet,K,2);
        correct=0;
        for j=1:size(TestSet,1)
        
            if ClassifiedSet(j,end) == TestSet(j,end)
             correct=correct+1;
            end
 
        end
        
        p=[p;(correct/all)];
    end
   result=[Data p];
end
