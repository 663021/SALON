   M S B A M L   `   `   `  ���� @  <SALON, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SALONSALON      SALON.Window5   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     %localclr-namespace:SALON     -     � Title$  Window1��$��776.175��$��653.02�����	#FF323232 � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=�.��� ���	#FF412244.+��� $,��&Информация о клиенте��$
��Left=�$	��132��$��
33,520,0,0q�$	��Top=�$	��589��
�������
��������� -    ��Name$ label��$2��,Форма добаление записей��$��Center=�$��214,22,204,0q�$	��Top=�$��0��$��18(�
�������$	��235���� -   $ label_Copy2��$��© SALON 2019��$
��Left=�$��278,735,0,0q�$��0��$	��Top=����	#FF9276DE$��12(���Z� �� -   $ label_Copy3��$�� ��$
��Left=�$��
10,719,0,0q�$��0��$	��Top=����	#FF9276DE$��12(�$	��630�����	#FF9276DE$��1���� -   $ label_Copy4��$�� ��$
��Left=�$��	10,80,0,0q�$��0��$	��Top=����	#FF9276DE$��12(�$	��630�����	#FF9276DE$��1���� -    ��Name$ image_log_out��$
��Left=�$��32��$��	80,25,0,0q�$	��Top=�$��34��$
��Fill=��� -   $ image_close��$
��Left=�$��33��$��
590,25,0,0q�$	��Top=�$��33��$
��Fill=��� -   $ 
image_back��$
��Left=�$��33��$��	25,25,0,0q�$	��Top=�$��33��$
��Fill=�&   System.Windows.Controls.DataGrid  -	     Name$ 	DataGrid1��$
��Left=�$	��157��$��
26,293,0,0q�$	��Top=�$	��606��$��14(�   
IsReadOnly .    RowBackground �	#FF2B172C	   AlternatingRowBackground	 �	#FF2B172C���	#FF858585
   HorizontalGridLinesBrush
 �	#FFF5F5FA   VerticalGridLinesBrush �	#FF2B172C��Z�    Columns 4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate �� .R��� -
   �� -    ��Name$ button��$��Добавить��$
��Left=�$��215,671,0,0q�$��0��$	��Top=�$	��204�����	#FF231616�� -    ��Name$ textBox_Copy��$
��Left=�$��23��$��227,211,0,0q� �� TextWrapping$
 Wrap=�$�� ��$��0��$	��Top=�$	��200�����	#FF231616�� -   $ label_Copy1��$��
Время��$
��Left=�$��152,211,0,0q�$��0��$	��Top=�
��������� -    ��Name$ combo��$
��Left=�$��227,105,0,0q�$	��Top=�$	��200����Z� ��Z� �� -   $ 
label_Copy��$��Мастер��$
��Left=�$��151,104,0,0q�$��0��$	��Top=�
�������(  "System.Windows.Controls.DatePicker  -     Name$ 
label_time��$
��Left=�$��225,155,0,0q�$	��Top=�$	��242��   SelectedDateFormat$
 Long=��� -   $ label_Copy5��$��Дата��$
��Left=�$��152,158,0,0q�$��0��$	��Top=�
��������� -   $ label_Copy6��$��Услуги��$
��Left=�$��303,253,0,0q�$��0��$	��Top=�
��������� -   $ textBox_Copy1��$
��Left=�$��23��$��220,552,0,0q�$
 Wrap=�$�� ��$��0��$	��Top=�$	��200�����	#FF231616�� -   $ label_Copy7��$��Имя клиента��$
��Left=�$��
96,552,0,0q�$��0��$	��Top=�
��������� -   $ textBox_Copy2��$
��Left=�$��23��$��220,601,0,0q�$
 Wrap=�$�� ��$��0��$	��Top=�$	��200�����	#FF231616�� -   $ label_Copy8��$#��Телефон клиента��$
��Left=�$��
94,601,0,0q�$��0��$	��Top=�
��������� -   $ textBox_Copy3��$
��Left=�$��23��$��222,474,0,0q�$
 Wrap=�$��0��$��0��$	��Top=�$	��200�����	#FF231616 �� 
IsReadOnly . �� -   $ label_Copy9��$��Цена��$
��Left=�$��140,474,0,0q�$��0��$	��Top=�
�������