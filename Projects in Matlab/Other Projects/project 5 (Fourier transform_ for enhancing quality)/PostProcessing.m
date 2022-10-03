function ImDom=PostProcessing(image)
for i=1:size(image,1)
    for j=1:size(image,2)
        image(i,j)=image(i,j)*((-1)^(i+j));
    end
end
ImDom=image;
end