%Space hase all sample space that we want to search. every sample is in
%each row.
 %-----------select randomly 1/3 of sample--------------
 load('sampleOfData1.mat');
 flag=zeros(size(Space,1),1); %it is column matrix ,used for not reselecting
 i=1;
 BaseCreation=[];
 while i <= m
    j=randi(size(Space,1),1);
    if flag(j,1)==0
        flag(j,1)=1;
        i=i+1;
    end
 end
 %--------------------------------------------------------
   for i=1:size(flag,1)
       if flag(i,1)==1
       BaseCreation=[BaseCreation;Space(i,:)];     %consist of 1/3 Space's data randomly
       end
   end
   
 
    EditableBaseCreation=BaseCreation;  %have this property that it can have added 
    %and removed data from the origin(BaseCreation) 
    PBaseCreation=Performance(BaseCreation);     %**<--- Performance related to pronblem.
    BaseCreation
    PBaseCreation
    %  BaseCreation and performance
    %Performance store in last column
    Best=GA(Space,PBaseCreation,m,Alphabet,1)     %*****<-- Alphabet related to problem .
    