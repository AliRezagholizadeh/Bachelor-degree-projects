function Best=GA(Space,OldCreation,m,Alphabet,WhichCreation)
%OldCreation have performance of each chromosome in last column 
% 'm' is population of each creation that is fix for all .
% Alphabet is 1*n matrix .
OldCreation
NewCreation=[];
Mson=[];
Cson=[];
Cdoughter=[];
if WhichCreation < 10
    EditableOldCreation=OldCreation; %each selecting from old creation to 
    %construct new creation performs by means of Editable Old Creation .
    Perform=OldCreation(:,end);
    %----------------find data that have max performance-------------
    M=max(Perform)
    BMaxPMatrix=(Perform==M(1,1)); %Bool max performance matrix
    MaxPData=[];
    if sum(BMaxPMatrix) > 2      
        for l=1:size(BMaxPMatrix,1)
            if BMaxPMatrix(l,1)==1
                 MaxPData=[MaxPData;OldCreation(l,:)]; %max performance data matrix
            end
        end
        MPD=MaxPData(randi(size(MaxPData,1),1));%Max performance Data
    else
        MPD=OldCreation(BMaxPMatrix,:);
    end
    %********THIS MAX PERFORMANCE DATA MOVE TO NEW Creation*********** 
    NewCreation=[NewCreation;MPD]
    EditableOldCreation= Removing(EditableOldCreation,MPD);       % remove second input data from the first.
    %*************************************************************
    %---------------Select Parent from OldCreation--------------
    NP=randi([(m-1)/2 m-1],1)    %Number of Parent
    Parent=RollerSelector(OldCreation,NP)
 
        %--------Use tow method for reproduction---------- 
        
     K=randi([1 NP],1) % 'K' parent for construct child
     Parent2=Select(Parent,K)
    K1=randi(K,1)  % 'K1' parent for construct children by means of 'mutation' .
    ParentMMC=Select(Parent2,K1)    % Parent for Mutation Make Children
    ParentCMC=Removing(Parent2,ParentMMC)   % Parent for Cross Over Make Childeren .
    Mson=Mutation(ParentMMC,Alphabet)  %Mutation son
    [Cson Cdoughter]=CrossOver(ParentCMC)  %Cson & Cdoughter  are  sets
    %of sons & doughters performed by CrossOver
    %**********CHILDEREN MOVOE TO NEW CCREATION ******************
    if size(Mson,1)~=0
        NewCreation=[NewCreation;Mson];
    end
    if size(Cson,1)~=0
         NewCreation=[NewCreation;Cson];
    end
     if size(Cdoughter,1)~=0
        NewCreation=[NewCreation;Cdoughter];
     end
    %*************************************************************
    NewCreation
    NeededPeople=m-size(NewCreation,1);
    RemainSet=Select(Space,NeededPeople);  % we select from Space randomly  AND then 
    % we perform performance of these and then we adding these to
    % NewCreatian .
    RemainSet=Performance(RemainSet);
    NewCreation=[NewCreation;RemainSet]
    
    Plot(NewCreation,WhichCreation);
    GA(Space,NewCreation,m,Alphabet,WhichCreation+1);
else
    Best=[];
    p=OldCreation(:,end);
    m=max(p);
    LBest=(p==m(1,1));
    for i=1:size(LBest,1)
        if LBest(i,1)==1
            Best=[Best;OldCreation(i,:)];
        end
    end
end
    
end


function selected=Select(Matrix,n)
% Matrix are used 
%that Matrix for creation must be called by Editable Old Creation .
%Matrix for select parent must be called by Old Creation .
flag=zeros(size(Matrix,1),1); %it is column matrix ,used for not reselecting
 i=1;
 selected=[];
 while i <= n
    j=randi([1 size(Matrix,1)],1);
    if flag(j,1)==0
        flag(j,1)=1;
        i=i+1;
    end
 end
 for i=1:size(flag,1)
     if flag(i,1)==1
         selected=[selected;Matrix(i,:)];
     end
  end
end


function selected=RollerSelector(Matrix,n)
    roll=[];
    selected=[];
    for i=1:size(Matrix,1)
        repeat=Matrix(i,end);
        while repeat > 0
            roll=[roll;Matrix(i,:)];
            repeat=repeat-1;
        end
    end
 flag=zeros(size(roll,1),1); %it is column matrix ,used for not reselecting
 i=1;
 while i <= n
    j=randi(size(Matrix,1),1);
    if flag(j,1)==0
        flag(j,1)=1;
        i=i+1;
    end
    if i==n+1
        flag=Compress(roll,flag);
        i=sum(flag)+1;
    end
 end
 for i=1:size(flag,1)
     if flag(i,1)==1
        selected=[selected;Matrix(i,:)];
     end
 end
end
function compressed=Compress(Matrix,flag)
% This function remove all data that selected(by flag) except one and
% returnt such the flag parametere.
    for i=1:size(Matrix,1)       
        if flag(i,1)==1
            curr=Matrix(i,:);
            j=i+1;
            while j <= size(Matrix,1) & flag(j,1)==0
                j=j+1;
            end
            while j<=size(Matrix,1) & curr==Matrix(j,:) & flag(j,1)==1
                flag(j,1)=0;
                while j<=size(Matrix,1) & flag(j,1)==0
                    j=j+1;
                end
                i=j;
            end
        end
    end
    compressed=flag;
end

