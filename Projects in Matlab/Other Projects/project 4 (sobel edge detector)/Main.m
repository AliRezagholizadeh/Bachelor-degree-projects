%sobel edge detector 
image=rgb2gray(imread('1.jpg'));
imshow(image);
title('Original Image');
X_Dimage=X_Derivative(image);
X_Dresult=X_Dimage;
figure,imshow(X_Dresult);
title('dI/dx');
%Find of vertical and horizontal edge
Y_Dimage=Y_Derivative(image);
Y_Dresult=Y_Dimage;
figure,imshow(Y_Dresult);
title('dI/dy');
%To Combine two separate detected edge 
X_Dimage=double(X_Dimage);
Y_Dimage=double(Y_Dimage);
X_Dimage=X_Dimage.^2;
Y_Dimage=Y_Dimage.^2;
COM_result=sqrt(X_Dimage+Y_Dimage);
figure,imshow(uint8(COM_result));
title('combining with out treshoulding');
%selecting from combined matrix 
T_matrix=Treshould(COM_result,100);     
figure,imshow(T_matrix);    
title('Combined and Treshould by 100');
%-----------------------------until now we obtain sharp poit
image=double(image)+T_matrix;
image=uint8(image);
figure,imshow(image);
title('added edge to original image');
