function Plot(Creation,n)
% n showw n ed creation .
    figure;
    x=[1:size(Creation,1)];
    p=transpose(Creation(:,end));
    plot(x,p,'.b');
    s=['plot',48+n,' s creation'];
    title(s);
    
end