using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn20_9.Abstract
{
    // Không phải class
    // Chỉ có chưa những phương thức chưa được thực thi (Abstract method) => Mất normal method (Mất tính tối ưu code)
    // Nó định nghĩa khuôn mẫu, hành vi cho 1 nhóm tượng
    // Hỗ trợ đa kế thừa

    // Ưu điểm:
    //  Đa kế thừa
    //  Xây dựng bộ khung mà các lớp con phải làm theo
    //  Giúp quản lý tốt các đầu công việc mà một lớp con phải thực hiện
    
    // Nhược điểm
    // Mất normal method
    public interface ManInterface
    {
        public abstract string LayVo();
    }
}
