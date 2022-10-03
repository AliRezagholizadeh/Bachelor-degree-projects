function ClassifiedSet=ClassifyByBayes(TrainSet,TestSet,NumberOfClass)
syms x;

    %-----------separate each class of Training Set-----------
    Classes=cell(1,NumberOfClass);
    for i=1:NumberOfClass
      Classes{1,i}=cell(4,1);%Store Training point in each class 
     %correspond to its column index(for instance i's class store in 
     %classes{1,i}{1,1})and Mean of ech class(store in Classes{1,i}{2,1})and 
     %variance is stored in Classes{1,i}{3,1}.Each of these(mean and
     %variance are column matrix.
    end
    for i=1:NumberOfClass
        LCurrclass=(TrainSet(:,end)==(i-1));   %label of current class
        Currclass=TrainSet(LCurrclass,1:end-1);   %with out label
        
        Classes{1,i}{1,1}=Currclass(:,1:end);  %stor with out label
        %a=Classes{1,i}{1,1}
    end
    %-----------Find mean of each class------------------------
    Sum=0;
    for i=1:NumberOfClass
        Points=Classes{1,i}{1,1};   %each point is in row
       if size(Points,1)>0
        Sum=sum(Points);            %execute sum of each dimention
        Mean=Sum./(size(Points,1));    %execute Mean of each dimention
        %Mean is (dimention of point)*1.
        Classes{1,i}{2,1}=Mean;
        
        MeanSet=[];     %at last became same size of Points matrix to excecute legaly
        for j=1:size(Points,1)
            MeanSet=[MeanSet;Mean];
        end
        Variance =sum((Points-MeanSet).^2);
        Variance=(Variance./size(Points,1));
        
        SD=Variance.^0.5;   % SD is row matrix
        Classes{1,i}{4,1}=SD;
        Sum=0;
       end
    end
    
    for i=1:NumberOfClass
        Points=Classes{1,i}{1,1};
       if size(Points,1)>0
        Cov=Covariancefunc(Points); %Covariancefunc:calculate covariance 
        %therough each column (dimention is number of column);Cov is
        %(dim*dim) matrix.
        Classes{1,i}{3,1}=Cov;
       end
 
    end
    %---------------------- classifying Test points----------------
    index=[0:NumberOfClass-1];
    ClassifiedSet=[];
    for i=1:size(TestSet,1)
        currPoint=transpose(TestSet(i,1:end-1)); %currPoint is column matrix
        Posterior=zeros(1,NumberOfClass);   %THIS IS ROW MATRIX THAT SRORES posterior of each class
        for j=1:NumberOfClass
            Cov=Classes{1,j}{3,1};
            po=Classes{1,j}{1,1};
            d=size(po,2);
            m=transpose(Classes{1,j}{2,1});    %naw SD is column matrix
            Pi=1/(NumberOfClass); %Pi is prior for i-th class
            P=-(d/2)*log(2*pi)-0.5*log(det(Cov))-0.5*(transpose(currPoint-m))*(inv(Cov)*(currPoint-m))+log(Pi);
            Posterior(1,j)=P;
        end
        c=index(Posterior == max(Posterior));
        if size(c,2)>0
        c=c(1,randi([1 size(c,2)],1));
        ClassifiedSet=[ClassifiedSet;transpose(currPoint) c];
        end
    end
            
end