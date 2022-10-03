function [theta, J_history,err] = gradientDescentMulti(X, y, theta, alpha, num_iters)
%GRADIENTDESCENTMULTI Performs gradient descent to learn theta
%   theta = GRADIENTDESCENTMULTI(x, y, theta, alpha, num_iters) updates theta by
%   taking num_iters gradient steps with learning rate alpha

% Initialize some useful values
m = length(y); % number of training examples
J_history = zeros(num_iters, 1);
err=0;
%theta0=theta;
for iter = 1:num_iters

    % ====================== YOUR CODE HERE ======================
    % Instructions: Perform a single gradient step on the parameter vector
    %               theta. 
    %
    % Hint: While debugging, it can be useful to print out the values
    %       of the cost function (computeCostMulti) and gradient here.
    %


N= size(X,2);
Z=X;

a=ones(N,1);
%a1=a;

b=X*theta - y;
for j=1:N
    Z(:,j) = b(:) .* X(:,j);  
end

%b = X * theta;
%for j=1:N
%    s=0;
%    for i=1:m
%        s = s + (b(i)-y(i))* X(i,j);
%    end
%    a1(j) = alpha * (1/m) * s;
%end
    
    a(:)=(sum(Z))';
    a = alpha * (1/m) * a; 
 %   fprintf('a: \n');
    theta(:) = a(:);
 %   fprintf('a1: \n');
 %  theta(:) =theta(:) - a1(:);

    % ============================================================

    % Save the cost J in every iteration    
    J_history(iter) = computeCostMulti(X, y, theta);
    

    if mod(iter,10)==0
        j=iter;
        c=0;     
        for i=iter:-1: (iter-8)
            if J_history(j) > J_history(j-1)
                j=j-1;
                c=c+1;
            end
            if c > 5
                err=1;
                break;
         
            end
        end
    end
    
   if err==1 
 %      theta=theta0;
       iter= num_iters;
        break;
   end
    

 end

end
