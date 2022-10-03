load('Data_hoda_full.mat')
% PCA for your database 
for i=1:60000
A=imresize(Data{i},[28,28]);
DATA(i,:)=A(:);
end
DATA_arange=PCA(DATA,150);

 [B,IX]=sort(randi(size(DATA_arange,1),[size(DATA_arange,1) 1]),1);
        MixedSet=DATA_arange;
        for l=1:size(DATA_arange,1)
            MixedSet(l,:)=DATA_arange(IX(l),:);
        end
        DATA_arange=MixedSet;
for i=1:10
    j=(DATA_arange(:,end)==i-1);
    DATA2(:,:,i)=DATA_arange(j,1:end-1);
end
DATA_arange2=DATA2;
Xtrain_new=DATA_arange2(1:1000,:,:); 
Xtest_new=DATA_arange2(1001:3000,:,:);
[m,n,p]=size(Xtrain_new);
prob_a;
prob_d;
%--------------------------------------------
Xtrain_new=[];
Xtest_new=[];
Xtrain_new=DATA_arange(1:1000,:) ;
Xtest_new=DATA_arange(1001:3000,:);

ClassifiedSet=K_NearestN(Xtrain_new,Xtest_new,1,10);
PerformanceOfKNN=Performance(ClassifiedSet,Xtest_new)
save('result1000')
ClassifiedSet=K_NearestN(Xtrain_new,Xtest_new,2,10);
PerformanceOfKNN=Performance(ClassifiedSet,Xtest_new)
save('2result1000')
ClassifiedSet=K_NearestN(Xtrain_new,Xtest_new,3,10);
PerformanceOfKNN=Performance(ClassifiedSet,Xtest_new)
save('3result1000')
