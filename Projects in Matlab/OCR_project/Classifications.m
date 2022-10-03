function Classifications(TrainSet,TestSet,NumberOfclass)
ClassifiedSet=one_nearestN(TrainSet,TestSet);  %in this function-
%assume that member of each class are same.
withOne_NN=ClassifiedSet;
PerformanceOf1NN=Performance(ClassifiedSet,TestSet)
max=0;

ClassifiedSet=K_NearestN(TrainSet,TestSet,2,NumberOfclass);
withK_NN=ClassifiedSet;
PerformanceOfKNN=Performance(ClassifiedSet,TestSet)

ClassifiedSet=ClassifyByBayes(TrainSet,TestSet,NumberOfclass);
PerformanceOfBayes=Performance(ClassifiedSet,TestSet)

ClassifiedSet=Parzen(TrainSet,TestSet,18,NumberOfclass); 
PerformanceOfParzen=Performance(ClassifiedSet,TestSet)
end