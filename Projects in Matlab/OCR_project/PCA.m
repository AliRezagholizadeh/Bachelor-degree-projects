function a=PCA(DATA,d)
DATA=DATA';
load('Data_hoda_full.mat')



DATA_n=double(DATA)-repmat(mean(DATA')',1,60000);
% load DATA_HODA
% PCA
% DATA_n=[1,2,3,4,5;1.5,1.6,3.3,7,9];
C=(DATA_n*DATA_n');
[U D V]=svd(C);
%plot(diag(D)/max(diag(D)))
V_pca=V(:,1:d);
Features=DATA_n'*V_pca;
Features=Features./repmat(max(Features),size(Features,1),1);
DATA_arange=[];
for i=1:10
J=find(labels==i-1);
DATA_arange=[DATA_arange;Features(J,:) repmat(i-1,size(J,1),1)];
end
a=DATA_arange;
save('DATA_arange','DATA_arange')