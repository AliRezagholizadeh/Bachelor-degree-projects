function [Son Doughter]=CrossOver(Parent)
%Parent has performance in last column.
Son=[];
Doughter=[];
if size(Parent,1) > 1
    for i=1:2:size(Parent,1)
        male=Parent(i,1:end-1);
        PM=Parent(i,end);
        if i+1 <= size(Parent,1)
            female=Parent(i+1,1:end-1);
            PF=Parent(i+1,end);
        else
            female=Parent(i-1,1:end-1);
            PF=Parent(i-1,end);
        end
        son=male;
        doughter=female;
        
        length=size(Parent,2)-1;
        if length/8 >= 1
            SubLen=floor(length/8);
        else
            for j=4:-2:1
                if length/j >= 1
                    SubLen=floor(length/j);
                    j=0;
                end
            end
        end
        j=1;
        priority=0;
        while j <= size(Parent,2)-1
            if priority==0
                j=j+SubLen;
                priority=SubLen;
            else
                son(1,j)=female(1,j);
                doughter(1,j)=male(1,j);
                j=j+1;
                priority=priority-1;
            end
        end
        Son=[Son;son];
        Doughter=[Doughter;doughter];
        Son=Performance(Son);
        Doughter=Performance(Doughter);
    end      
else
    if size(Parent,1)==1
        Son=Parent;
    end
end
                
end