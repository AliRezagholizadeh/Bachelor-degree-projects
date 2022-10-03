clear;
close all;
image=imread('2.tif');
imshow(image);
 title('Original Image');
preIm=preprocessor(image);      %preIm is double
FTedIm=FourierTransform(preIm); %FTedIm:frourier transformed image and is double
R=real(FTedIm);
I=imag(FTedIm);
spec=(R.^2+I.^2).^(1/2);    %spec is double
figure,imshow(log(spec+1),[]);
 title('centered Of Fourier transformed'); 
 %until now we calculate centered Fourier transformed Of Original image
%x=FilterFunction(FTedIm,'highpass',0.3);
%title('HighPass Mask');
%x=FilterFunction(FTedIm,'bandpass',[0.3,0.5]);
%title('BandPass Mask');
x=FilterFunction(FTedIm,'lowpass',0.7);
title('LowPass Mask');
y=InverseFT(x);
z=PostProcessing(y);

figure,imshow(uint8(z));
 title('Enhanced Image');
%  I=imread('1.tif');
% [m,n]=size(I);
% imshow(I)
% F=fft2(I);
% figure(1);
% imshow(log(abs(F)+1),[])
% S=abs(F);
% Fc=fftshift(F);
% Sc=abs(Fc);
% figure(2);
% imshow(log(abs(Fc)+1),[]);
% figure(3);
% mesh(Sc(220:280,220:280));
%  clear 
% close all
% 
% image=imread('1.tif');
% imshow(image);
% 
% preIm=preprocessor(image);      %preIm is double
%  %preIm is double
% FTedIm=FourierTransform(preIm); %FTedIm:frourier transformed image and is double
% 
% R=real(FTedIm);
% I=imag(FTedIm);
% spec=(R.^2+I.^2).^(1/2);
% 
% figure,imshow(log(spec+1),[]);