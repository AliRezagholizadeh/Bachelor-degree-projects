function ClassifiedSet=one_nearestN(TrainSet,TestSet)
%TrainSet:assemble of trainin samples from each class / TrainSet is n*3
%class1 and class2 are gained fram TRAIN
%faseleye az tak tak e noghat (che class1 va che class2) ra bedast miavarad
%bad minimum migirim then we assign this point to its class.

point=zeros(1,size(TrainSet,2)-1);
NearestPoint=zeros(1,size(TrainSet,2));
ClassifiedSet=[];
distanceOfNearPoint=1000;
    for j=1:size(TestSet,1)
        point(1,:)=TestSet(j,1:end-1);
        for i=1:size(TrainSet,1)            
            d=sqrt(sum((point(1,:)-TrainSet(i,1:end-1)).^2));
            if d < distanceOfNearPoint
                NearestPoint=TrainSet(i,1:end);
                distanceOfNearPoint=d;
            end
        end
        ClassifiedSet=[ClassifiedSet;point NearestPoint(1,end)];
        distanceOfNearPoint=2000;
    end
   
end