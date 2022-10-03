function Set=Data1(numberOfsample)
%numberOfsample: number of sample from each class
X=[-3:0.01:3];
Y=[3:-0.01:-3];
[x,y]=meshgrid(X,Y);
z=x.^2+y.^2;
z2=x.^2+(y+1).^2;
L1=(x<=0);
L2=(x>=0);
a=(z<=4);
b=(z2<=1);
c=(z<=1);
Ldtb1=(a&L1);                            %Ldtb1:logical data base 1 same size with x or y
Ldtb1=(Ldtb1|(b&L2));
Ldtb1=(Ldtb1-(double(c&L1)));
Ldtb1=(Ldtb1==1);
imshow(Ldtb1);
title('data base 1');

a=(z2<=4);
Ldtb2=(a&L2);                           %Ldtb2:logical data base 2 same size with x or y
Ldtb2=(Ldtb2|(c&L1));
Ldtb2=(Ldtb2-(double(b&L2)));
Ldtb2=(Ldtb2==1);
figure,imshow(Ldtb2);
title('data base 2');

dtb1x=x(Ldtb1);                         %real x data with lower size of x
dtb1y=y(Ldtb1);
%figure,plot(dtb1x(:,1),dtb1y(:,1));
dtb2x=x(Ldtb2);                         %is column matrix
dtb2y=y(Ldtb2);
%-----------------------------------------------------------
sample1=[];                             %from dtb1(az class 1 500 ta noghte entekhab mikone)
                                    %meghdari az in sample ra be onvane
                                    %TRAIN va beghiash ra baraye TEST
flag=zeros(size(dtb1x,1),1);        %darnazar gerefte mishe .
i=1;
while i <= numberOfsample
    ri=randi(size(dtb1x,1),1);    
    if flag(ri,1)==0
        rnx=dtb1x(ri,1);
        rny=dtb1y(ri,1);
        sample1=[sample1;rnx rny 1];
        i=i+1;
    end
end
sample2=[];                             %from dtb2 (az class 2 500 ta noghte entekhab mikone)
                                    %meghdari az in sample ra be onvane
                                    %TRAIN va beghiash ra baraye TEST
                                    %darnazar gerefte mishe .
flag=zeros(size(dtb2x,1),1);
i=1;
while i <= numberOfsample
    ri=randi(size(dtb2x,1),1);
    if flag(ri,1)==0
        rnx=dtb2x(ri);
        rny=dtb2y(ri);
        sample2=[sample2;rnx rny 2];
        i=i+1;
    end
end
figure,plot(sample1(:,1),sample1(:,2),'r.');
title('500 samples of class 1');

figure,plot(sample2(:,1),sample2(:,2),'b.');
title('500 samples of class 2');

Set=[sample1;sample2];
%---------------For mixture of samples----------------
 [B,IX]=sort(randi(size(Set,1),[size(Set,1) 1]),1);
        MixedSet=Set;
        for l=1:size(Set,1)
            MixedSet(l,:)=Set(IX(l),:);
        end
        Set=MixedSet;

end
