## MCV: Model - View - Cotnroller

### Enity Framework
	- Code First: ->>>>>>> model -> db
	- Migration:
			- Step.1: ADD-MIGRATION 'message' -p project_name
			- Step.2: UPDATE_DATABASE
			
### Triển khai module hoàn chỉnh:
	- KhachHang
	     - HienThiDuLieu
			 - Step.1: (Tạo bảng lưu dữ liệu)
					- Step.1.1: Tạo đối tượng "KhachHang" trong model
							- [Table("KhachHang")] => Chỉ định tên bảng cho model
							- [Key] => Đánh dấu đây là trường khóa chính
							- [DatabaseGenerated(DatabaseGeneratedOption.Identity)] => Đánh dấu trường giá trị tự tăng
					
					- Step.1.2: Khai báo model vào trong "Context"
					
					- Step.1.3: Migrate dữ liệu lên DB
			 
			 - Step.2: (Thực hiện lấy dữ liệu và xử lý dữ liệu theo yêu cầu)
					- Step.2.1: (Thực hiện lấy dữ liệu)
						- Step.2.1.1 Khai báo Interface (IService - IKhachHangService) 
						- Step.2.1.2 Triển khai Interface (Service - KhachHangService) 
						- Step.2.1.3 Khai báo DI trong StartUp 
								- eg: 
									#region DI : Dependency Injection
										services.AddTransient<ICustomerService, CustomerService>();
									#endregion
						- Step.2.1.4 Gọi vào Controller 



.gitignore: bỏ file cache, dll