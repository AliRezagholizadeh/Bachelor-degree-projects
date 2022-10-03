function PlotPerformance(Train1,Train2,Test1,Test2,TestSet,ClassifiedSet,statement)
    %By assumption that we have two classes 
    figure;
    
    %subplot(2,2,1);
%     plot(Train1(:,1),Train1(:,2),'r.',Train2(:,1),Train2(:,2),'b.',Test1(:,1),Test1(:,2),'r*',Test2(:,1),Test2(:,2),'b*');
%     title('correct classification');
        
    %subplot(2,2,2);
    figure;
    plot(Test1(:,1),Test1(:,2),'r.',Test2(:,1),Test2(:,2),'b.');
    title('Test data of each class');
    
    Lclass1=ClassifiedSet(:,end)==1;
    class1=ClassifiedSet(Lclass1,:);
    Lclass2=ClassifiedSet(:,end)==2;
    class2=ClassifiedSet(Lclass2,:); 
%     %subplot(2,2,3);
%     figure;
%     plot(Train1(:,1),Train1(:,2),'r.',Train2(:,1),Train2(:,2),'b.',class1(:,1),class1(:,2),'r*',class2(:,1),class2(:,2),'b*');
%     Statement=['classification by' statement];
%     title(Statement);
    
    %subplot(2,2,4);
    figure;
    plot(class1(:,1),class1(:,2),'r*',class2(:,1),class2(:,2),'b*');
    title(['Test data after classification by ' statement]);
    
    error0=0;
    FaultPoint=[];
    CorrectPoint=[];
    for i=1:size(TestSet,1)
         if ClassifiedSet(i,1:end-1) == TestSet(i,1:end-1) 
            
            if ClassifiedSet(i,end) ~= TestSet(i,end)
             FaultPoint=[FaultPoint;ClassifiedSet(i,1:end)];
            else
                CorrectPoint=[CorrectPoint;ClassifiedSet(i,1:end)];
            end
        else
            error0=error+1;
         end
    end
    error0;
    LFclass1=FaultPoint(:,end)==1;      %logic Fault point in class 1
    Fclass1=FaultPoint(LFclass1,:);     %Fault point in class 1
    LFclass2=FaultPoint(:,end)==2;
    Fclass2=FaultPoint(LFclass2,:);
    
    LCclass1=CorrectPoint(:,end)==1;      %logic Correct point in class 1
    Cclass1=CorrectPoint(LCclass1,:);     %Correct point in class 1
    LCclass2=CorrectPoint(:,end)==2;
    Cclass2=CorrectPoint(LCclass2,:);
    
    figure,plot(Cclass1(:,1),Cclass1(:,2),'r.',Cclass2(:,1),Cclass2(:,2),'b.',Fclass1(:,1),Fclass1(:,2),'r*',Fclass2(:,1),Fclass2(:,2),'b*');
    title(['Correct and fault point in classification of Test data by' statement]);
end