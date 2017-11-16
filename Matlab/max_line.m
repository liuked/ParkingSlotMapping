function [ xy_long ] = max_line( I )
%UNTITLED3 Summary of this function goes here
%   Detailed explanation goes here

% converto in scala di grigi
YCBCR = rgb2ycbcr(I);
I = YCBCR(:,:,1);

% eseguo la sogliatura
BW = im2bw(I, 155/255);

% eseguo la chiusura con un elemento quadrato 10x10px
se = strel('square',20);
BW = imclose(BW,se);
se = strel('disk',20);
BW = imerode(BW,se);

figure('Name','closed'), imshow(BW);

%eseguo la trasformata di Hough
[H,T,R] = hough(BW);
%imshow(H,[],'XData',T,'YData',R,'InitialMagnification','fit');
%xlabel('\theta'), ylabel('\rho');
%axis on, axis normal, hold on;


%Ricavo i massimi della trasformata
P  = houghpeaks(H,5,'threshold',ceil(0.5*max(H(:))));
x = T(P(:,2)); y = R(P(:,1));
%plot(x,y,'s','color','white');


%Find lines and plot them.

lines = houghlines(BW,T,R,P,'FillGap',5,'MinLength',7);
max_len = 0;
for k = 1:length(lines)
   xy = [lines(k).point1; lines(k).point2];
   %plot(xy(:,1),xy(:,2),'LineWidth',2,'Color','green');

   % Plot beginnings and ends of lines
   %plot(xy(1,1),xy(1,2),'x','LineWidth',2,'Color','yellow');
   %plot(xy(2,1),xy(2,2),'x','LineWidth',2,'Color','red');

   % Determine the endpoints of the longest line segment
   len = norm(lines(k).point1 - lines(k).point2);
   if ( len > max_len)
      max_len = len;
      xy_long = xy;
   end
end
%plot(xy_long(:,1),xy_long(:,2),'LineWidth',2,'Color','cyan');

end

