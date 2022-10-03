function preprocessedIm=preprocessor(image)
%first image is resized to become N*N  then we multiple image into (-1)^(i+j) 
image=imresize(image,[min(size(image,1),size(image,2)), min(size(image,1),size(image,2))]);
image=double(image);
for i=1:size(image,1)
    for j=1:size(image,2)
        image(i,j)=image(i,j)*(-1)^(i+j);
    end
end
preprocessedIm=image;
end