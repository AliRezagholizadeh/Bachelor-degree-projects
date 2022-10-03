clear all;
close all;
set=Data1(500); %500 sample from each class
% [Train1 Test1]=RandomSelectTRAININGandTESTset(set,1,200);
% [Train2 Test2]=RandomSelectTRAININGandTESTset(set,2,200);
[Train1 Test1]=PartSelectOfset(set,1,200,1);
[Train2 Test2]=PartSelectOfset(set,2,200,1);
TrainSet=[Train1;Train2];
TestSet=[Test1;Test2];
figure;
plot(Train1(:,1),Train1(:,2),'r.',Train2(:,1),Train2(:,2),'b.');
title('Train data of each class');
%---------------For mixture of Training point in each class----------------
[B,IX]=sort(randi(size(TrainSet,1),[size(TrainSet,1) 1]),1);
        MixedTrainSet=TrainSet;
        for l=1:size(TrainSet,1)
            MixedTrainSet(l,:)=TrainSet(IX(l),:);
        end
        TrainSet=MixedTrainSet;
%---------------For mixture of TestSet----------------
[B,IX]=sort(randi(size(TestSet,1),[size(TestSet,1) 1]),1);
        MixedTestSet=TestSet;
        for l=1:size(TestSet,1)
            MixedTestSet(l,:)=TestSet(IX(l),:);
        end
        TestSet=MixedTestSet;
%-----------------------------------------------------------

ClassifiedSet=one_nearestN(TrainSet,TestSet);  %in this function-
%assume that member of each class are same.
withOne_NN=ClassifiedSet;
PerformanceOf1NN=Performance(ClassifiedSet,TestSet)
PlotPerformance(Train1,Train2,Test1,Test2,TestSet,ClassifiedSet,'One_NN');   %For Data1 that have to classes
max=0;

ClassifiedSet=K_NearestN(TrainSet,TestSet,3,2);
withK_NN=ClassifiedSet;
PerformanceOfKNN=Performance(ClassifiedSet,TestSet)
str=['3' 'NN'];
PlotPerformance(Train1,Train2,Test1,Test2,TestSet,ClassifiedSet,str);   %By assumption
%that we have two classes

ClassifiedSet=ClassifyByBayes(TrainSet,TestSet,2);
PerformanceOfBayes=Performance(ClassifiedSet,TestSet)
PlotPerformance(Train1,Train2,Test1,Test2,TestSet,ClassifiedSet,'Bayes');

ClassifiedSet=Parzen(TrainSet,TestSet,2,2);
PerformanceOfParzen=Performance(ClassifiedSet,TestSet)
PlotPerformance(Train1,Train2,Test1,Test2,TestSet,ClassifiedSet,'Parzen');