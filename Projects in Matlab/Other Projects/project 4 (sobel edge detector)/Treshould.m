function result=Treshould(image,Number)
    result=zeros(size(image,1),size(image,2));
    for i=1:size(image,1)
        for j=1:size(image,2)
            if image(i,j) > Number
                result(i,j)=image(i,j);
            end
        end
    end
    
end