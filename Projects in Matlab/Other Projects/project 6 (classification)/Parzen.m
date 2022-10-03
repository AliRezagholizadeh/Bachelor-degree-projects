function Classified=Parzen(TrainSet,TestSet,r,NumberOfClass)
    ClassifiedSet=[];
    for i=1:size(TestSet,1)
        Point=TestSet(i,1:end-1);
        NearestSet=[];
        for j=1:size(TrainSet,1)
            TrainPoint=TrainSet(j,1:end-1);
            dis=sqrt(sum((Point-TrainPoint).^2));
            if dis <= r
                NearestSet=[NearestSet;TrainPoint TrainSet(j,end)];
            end
        end
        ClassifiedSet=ParzenDecision(NearestSet,ClassifiedSet,Point,NumberOfClass);   
    end
    Classified=ClassifiedSet;

end
function Classified=ParzenDecision(NearestSet,ClassifiedIn,Point,NumberOfClass)
    %in this function we use Parzen method (we construct normal destribute 
    %for each point of one class and then we sum them.
    %NearestSet consist of real label of each point at end column .
    label=NearestSet(:,end);
    Px=zeros(1,NumberOfClass);
    for i=1:NumberOfClass        
        ThisClass=(label==i);
        Class=NearestSet(ThisClass,1:end-1);  % find each point of i's class.
        %points in Class is with out label
        Px(1,i)=Priority(Class,Point,NumberOfClass);
      
    end
      m=Px(1,1);
        index=[];
        for h=1:NumberOfClass
            if Px(1,h) > m
                ind=h;
                index=[];
                index=[ind];
                m=Px(1,h);
                
            end
            if Px(1,h) == m
                index=[index;h];
            end
        end
        if size(index,1)==1
            y=1;
        else
            y=randi([1,size(index,1)],1);
        end
        c=index(y,1);
        ClassifiedIn=[ClassifiedIn;Point c];
    Classified=ClassifiedIn;
end

function g=Priority(Class,Point,NumberOfClass)
%assume gousian function for each point in class and gain probablity of
%being 'Point' in this class
g=0;
Point=transpose(Point);
    for i=1:size(Class,1)
        Xi=Class(i,:);
        m=transpose(Xi);
        Cov=0.05.*[0.5 0;0 0.5];
        d=size(Xi,2);
        Pi=1/(NumberOfClass);
        g=g+(-(d/2)*log(2*pi)-0.5*log(det(Cov))-0.5*(transpose(Point-m))*(inv(Cov)*(Point-m))+log(Pi));
    end

end