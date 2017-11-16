I = imread('parcheggio.png');
max = max_line(I);

I_r = imread('parcheggio_r.png');
max_r = max_line(I_r);

I_r_r = imread('parcheggio_r_r.png');
max_r_r = max_line(I_r_r);


% plotto le 3 immagini con la loro massima linea
%BASE -> VERDE
%_r -> ROSSO 
%_r_r -> BLUE

figure; imshow(I), hold on,
plot(max(:,1),max(:,2),'LineWidth',2,'Color','green');
% Plot beginnings and ends of lines
plot(max(1,1),max(1,2),'x','LineWidth',2,'Color','white');
plot(max(2,1),max(2,2),'x','LineWidth',2,'Color','white');

figure; imshow(I_r), hold on,
plot(max_r(:,1),max_r(:,2),'LineWidth',2,'Color','red');
% Plot beginnings and ends of lines
plot(max_r(1,1),max_r(1,2),'x','LineWidth',2,'Color','white');
plot(max_r(2,1),max_r(2,2),'x','LineWidth',2,'Color','white');

figure; imshow(I_r_r), hold on,
plot(max_r_r(:,1),max_r_r(:,2),'LineWidth',2,'Color','blue');
% Plot beginnings and ends of lines
plot(max_r_r(1,1),max_r_r(1,2),'x','LineWidth',2,'Color','white');
plot(max_r_r(2,1),max_r_r(2,2),'x','LineWidth',2,'Color','white');

figure, imshow(I), hold on,
plot(max(:,1),max(:,2),'LineWidth',2,'Color','green');
plot(max_r(:,1),max_r(:,2),'LineWidth',2,'Color','red');
plot(max_r_r(:,1),max_r_r(:,2),'LineWidth',2,'Color','blue');

% estraggo i coefficienti angolari e quindi gli angoli di inclinazione
% (tramite arcotangente)
M = (max(1,2)-max(2,2))/(max(1,1)-max(2,1));

M_r = (max_r(1,2)-max_r(2,2))/(max_r(1,1)-max_r(2,1));

M_r_r = (max_r_r(1,2)-max_r_r(2,2))/(max_r_r(1,1)-max_r_r(2,1));

A =radtodeg(atan(M));
A_r = radtodeg(atan(M_r));
A_r_r = radtodeg(atan(M_r_r));

% calcolo gli angoli di rotazione dall'immagine originale
TiltOf_r = A-A_r
TiltOf_r_r = A-A_r_r