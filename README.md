Aplicația Breast Cancer Detection with AI este o soluție Windows Forms dezvoltată în C# care are ca scop asistarea procesului de analiză a imaginilor mamografice, utilizând tehnici avansate de preprocesare și inteligență artificială.

Utilizatorii pot încărca imagini în format PGM provenite din investigații mamografice, iar aplicația oferă o interfață interactivă pentru vizualizarea acestora, cu funcționalități de zoom-in, zoom-out și selectarea regiunilor de interes (ROI). Regiunile selectate pot fi segmentate automat folosind algoritmul GrowCut, facilitând evidențierea zonelor potențial relevante din punct de vedere medical.

Pentru îmbunătățirea calității imaginilor și facilitarea unei analize mai precise, aplicația integrează un modul de preprocesare a imaginilor, care include:

Eliminarea zgomotului de fundal utilizând Haar Matrix;

Eliminarea artefactelor nedorite din imagine;

Îmbunătățirea contrastului folosind algoritmul CLAHE (Contrast Limited Adaptive Histogram Equalization).

Aplicația beneficiază și de un model de inteligență artificială dezvoltat cu ML.NET, care clasifică tipul de țesut mamar prezent în imagine în una dintre cele trei categorii: Fatty, Fatty-Glandular, sau Glandular-Dense. Acest model a fost antrenat pe o bază de date cu peste 3000 de imagini mamografice, oferind astfel un grad ridicat de acuratețe în predicții.

În plus, aplicația include și un modul de analiză statistică a imaginilor, oferind afișarea histogramei și a histogramei cumulative, utile pentru evaluarea distribuției intensităților pixelilor și a contrastului imaginii.
