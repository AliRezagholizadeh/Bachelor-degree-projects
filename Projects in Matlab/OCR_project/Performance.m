function result=Performance(ClassifiedSet,Test)
%ClassifiedSet is same size of Test.
% Rlabel=Test(:,end); 
% label=ClassifiedSet(:,end);
% accurrence=zeros(10,10);
% for i=0:9
%     this=(Rlabel==i);
%     thisLab=Rlabel(this,1);
%     thatLab=label(this,1);  
%     for j=1:size(thatLab,1)
%         accurrence(i+1,thatLab(j,1)+1)=accurrence(i+1,thatLab(j,1)+1)+1;
%     end
%     accurrence(i+1,:)=accurrence(i+1,:) ./ size(thatLab,1);
% end
% result=accurrence;
correct=0;
error=0;
    for i=1:size(Test,1)
        if ClassifiedSet(i,1:end-1) == Test(i,1:end-1) 
            
            if ClassifiedSet(i,end) == Test(i,end)
             correct=correct+1;
            end
        else
            error=error+1;
        end
    end
all=size(Test,1);
result=(correct/all);
% error;
% correct;
end
