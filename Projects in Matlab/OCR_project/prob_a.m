
load DATA_arange

% Xtrain_new=DATA_arange(1:1000,:,:); 
% Xtest_new=DATA_arange(1001:3000,:,:);
% [m,n,p]=size(Xtrain_new);
% n should be the number of features
% m is the number of samples
% p is the number of classes

mu = zeros(p,n);
mu = [mean(Xtrain_new(:,:,1));mean(Xtrain_new(:,:,2));mean(Xtrain_new(:,:,3));mean(Xtrain_new(:,:,4));mean(Xtrain_new(:,:,5));mean(Xtrain_new(:,:,6));mean(Xtrain_new(:,:,7));mean(Xtrain_new(:,:,8));mean(Xtrain_new(:,:,9));mean(Xtrain_new(:,:,10))];


pdf_mean = zeros(1,n,p);
pdf_var = zeros(n,n,p);

for cnt = 1:p
    hlp=(Xtrain_new(:,:,cnt)-repmat(mu(cnt,:),m,1));
    pdf_var(:,:,cnt) = (Xtrain_new(:,:,cnt)-repmat(mu(cnt,:),m,1))'*(Xtrain_new(:,:,cnt)-repmat(mu(cnt,:),m,1))*(1/(m-1));  
end




Conf=zeros(p,p);
CCR=zeros(p,p);

%Making Gaussian Pdf
for k=1:10
for j=1:m
    for i=1:p
        f(j,i)= exp((Xtrain_new(j,:,k)-mu(i,:))*pdf_var(:,:,i)*(Xtrain_new(j,:,k)-mu(i,:))');
    end
end
[a,index]=max(f,[],2);

for l=1:m
    S=sort(f(l,:),'descend');
    [h,index]=max(f(l,:));
    Conf(k,index)=Conf(k,index)+((S(1)-S(2))/(S(1)));
    CCR(k,index)=CCR(k,index)+1;
end

end
Perf=(CCR)/(m);
save('performanceOfBayes','Perf');
Conf/(m)
ACCR=trace(CCR)/(m*p)
Conf=Conf./(CCR+eps);
CCR=CCR/m;
A_conf=diag(Conf(:,1:p))'
A_CCR=diag(CCR(:,1:p))'