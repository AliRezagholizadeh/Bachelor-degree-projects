function space=Cspace

space3=[];
cromosome=[0 0 0];
one=[0 0 1];
i=0;
while i<= 400
     newCromosome=cromosome+one;
     cromosome=check(newCromosome);
end
space=space3;
end

function t=check(c)
    i=3;
    for i=3:-1:1
        if c(1,i)==10
            c(1,i)=0;
            if i>1
                c(1,i-1)=c(1,i-1)+1;
            end
        end
    end
       t=c;     
end