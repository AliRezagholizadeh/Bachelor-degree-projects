function transportedMat=TransitionFunc(EigenVector,matrix,dim)
%each point in EigenVector is column array
EigenVector=[-0.6778 -0.7351;
            -0.7351   0.6778];
transportedMat=[];
    transportedMatrix=transpose(EigenVector(:,1:dim));
    for i=1:size(matrix,1)
         point=transpose(matrix(i,:));
          NewPoint=transportedMatrix*point; %New point is column matrix
          transportedMat=[transportedMat;transpose(NewPoint)];
    end
   
end