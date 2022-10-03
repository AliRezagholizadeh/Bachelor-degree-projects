
% load DATA_arange
% Xtrain_new=DATA_arange(1:1000,:,:); 
% Xtest_new=DATA_arange(1001:3000,:,:);
% [m,n,p]=size(Xtrain_new);

m=size(Xtrain_new,1);
n=size(Xtrain_new,2);
Xtest_new=Xtrain_new;
mt=size(Xtest_new,1);
%class number
CN=10;

% h=5:5:10;
h=0.5;
performance=zeros(1,size(h,2));
for T=1:size(h,2)
CCR=zeros(CN,CN);
Conf=zeros(CN,CN);
for i=1:CN
    for j=1:mt
        count=zeros(1,CN);
        for k=1:CN
            a=(Xtrain_new(:,:,k)-repmat(Xtest_new(j,:,i),m,1))<h(T)*ones(m,n);   
            count(k)=size(find(sum(a,2)==n),1);
            
        end
        S=sort(count,'descend');
        [l,C]=max(count);
        Conf(i,C)=Conf(i,C)+(S(1)-S(2))/(S(1)+eps);
        CCR(i,C)=CCR(i,C)+1;
    end
end
performance(T)=trace(CCR)/(mt*CN);
T
performance(T)
Confidence(:,:,T)=Conf; 
Confusion(:,:,T)=CCR;
end

figure (1)
plot(h,performance,'--*','LineWidth',2)
set(gca,'fontweight','b')
xlabel('h_s_i_z_e')
ylabel('Fitness')
grid on;

[l,index]=max(performance);
l
ACCR=trace(Confusion(:,:,index))/(mt*CN)
CCR=Confusion(:,:,index)/mt
Conf=Confidence(:,:,index)/mt;
A_conf=diag(Conf(:,1:10))'
A_CCR=diag(CCR(:,1:10))'