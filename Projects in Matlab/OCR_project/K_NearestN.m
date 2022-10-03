function ClassifiedSet=K_NearestN(TrainSet,TestSet,K,NumberOfClass)
%TrainSet is Train point in each class (each point is in row)
%TestSet is n*2 matrix that you must never confident on second column
%(first column is point(in each dimention)).
K_SelectedPointSet=[];         %is k*2 matrix that store point in first column and Label in second. 
% DistanceFromK_Selected=[];   %respectivly to K_NearestPointSet / is k*1 matrix
 ClassifiedSet=[];
% LocalD=0;
% %LocalD is Max Distance of point from K selected as nearest point of Training Set 
% pivot=[TestSet(1,1:end-1)];      
% %pivot is one of the Test point . we want just find distance this piont
% %from other Training Set ,and use these to finde distance for other Test
% %points. BUT AT LAST WE DONT USE THIS THINKING BECOUSE OF MORE TIME
% %NESESSERY TO COMPUTE.
% DistanceFromPivot=[];   %is (number of TrainSet)*3 that store distance of 
% %correspond point(that store in first column)from Pivot in third column
% %and second column is label of correspond point in column 1.
% d=1;
       %---------------Find K nearest point from PIVOT--------------
%     for i=1:size(TrainSet,1)            
%             d=sqrt(sum((pivot(1,:)-TrainSet(i,1:end-1)).^2));
%             if LocalD > d
%                 replaceNum=max(DistanceFromK_Selected);
%                 b=(DistanceFromK_Selected == replaceNum);
%                 DistanceFromK_Selected(b)=d;
%                 index=transpose([1:K]);              
%                 ind=index(b); 
%                 K_SelectedPointSet(ind(1,1),:)=TrainSet(i,:);
%                 
%                 LocalD=max(DistanceFromK_Selected);
%               
%             end
%             if i <= K 
%                 DistanceFromK_Selected=[DistanceFromK_Selected;d];
%                 K_SelectedPointSet=[K_SelectedPointSet;TrainSet(i,:)];
%                 if i==K
%                     LocalD=max(DistanceFromK_Selected);
%                 end
%             end
%             DistanceFromPivot=[DistanceFromPivot;TrainSet(i,:) d];
%     end
%     ClassifiedSet=LabelUnKnownPoint(pivot,K_SelectedPointSet,ClassifiedSet,NumberOfClass);
    DistanceFromThis=[];    %Distance of other Traning point From current 
    %Test point. DistanceFromThis is n*3 that first column place Train point
    %label and distance also place in second and third respectively
    for j=1:size(TestSet,1)
        j
        TestSet(j,:);
        point(1,:)=TestSet(j,1:end-1);
        close all
        %plot(point(1,1),point(1,2),'+r',TrainSet(:,1),TrainSet(:,2),'.b');
        %---------------Find K nearest point--------------
        for i=1:size(TrainSet,1)            
            d=sqrt(sum((point(1,:)-TrainSet(i,1:end-1)).^2));
            DistanceFromThis=[DistanceFromThis;TrainSet(i,1:end) d];
        end
        dis=DistanceFromThis(:,end);
        [B,IX]=sort(dis,1);
        SortedDFT=zeros(size(DistanceFromThis,1),size(DistanceFromThis,2));
        for l=1:size(DistanceFromThis,1)
            SortedDFT(l,:)=DistanceFromThis(IX(l),:);
        end
        SortedDFT;
        for h=1:K
            K_SelectedPointSet=[K_SelectedPointSet;SortedDFT(h,1:end-1)];
        end  
        %K_SelectedPointSet
        ClassifiedSet=LabelUnKnownPoint(point,K_SelectedPointSet,ClassifiedSet,NumberOfClass);
        %this function do labeling by means of K selected point's label 
        DistanceFromThis=[];
        K_SelectedPointSet=[];
        save('Classified1000','ClassifiedSet')
    end
    
end

function ClassifiedSet=LabelUnKnownPoint(point,K_SelectedPointSet,ClassifiedSetIn,NumberOfClass)
    %K_SelectedPointSet is k*2 matrix that store point in first column and
    %Label in second.
    %with assumption that label of each class are from 1 to NumberOfClass
    %(Note in 1).
    LabelArray=K_SelectedPointSet(:,end);
    NumberInEachClass=zeros(NumberOfClass,1);   %is column matrix that stor
    %number of piont in each class(WhatPoint is in K_SelectedPointSet).
    for i=0:NumberOfClass-1
         NumberInEachClass(i+1,1)=sum(LabelArray==i);
    end
    ClassLabel=LaUnPoByK_NNStrategy(NumberInEachClass);
    ClassifiedSetIn=[ClassifiedSetIn;point ClassLabel];
    ClassifiedSet=ClassifiedSetIn;
    
end

function ClassLabel=LaUnPoByK_NNStrategy(NumberInEachClass)
%NumberInEachClass is single column that show number of point in
%each(1,2,..)class(correspond to its index).
%class
index=transpose([0:size(NumberInEachClass,1)-1]);
    CL=index(NumberInEachClass==max(NumberInEachClass));
    ClassLabel=CL(1,1);
end