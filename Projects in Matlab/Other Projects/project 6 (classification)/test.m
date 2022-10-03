function one_nearest(point,class1,class2)
    distance1=[];
%class1 and class2 are gained fram TRAIN
%faseleye az tak tak e noghat (che class1 va che class2) ra bedast miavarad
%bad minimum migirim then we assign this point to its class.  
    for i=1:size(class1,1)
        d=(point(1,1)-class1(i,1))^2+(point(1,2)-class1(i,2))^2;
        distance1=[distance1;d];
    end
    distance2=[];
    for i=1:size(class2,1)
        d=(point(1,1)-class2(i,1))^2+(point(1,2)-class2(i,2))^2;
        distance2=[distance1;d];
    end
    mDis1=min(distance1);
    mDis2=min(distance2);
    if(mDis1<mDis2)
        class1=[class1;point];
    else
        class2=[class2;point];
    end
end