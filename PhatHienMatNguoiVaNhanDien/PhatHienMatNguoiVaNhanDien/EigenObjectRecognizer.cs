using System;
using System.Diagnostics;
using Emgu.CV.Structure;

namespace Emgu.CV
{
    /// <summary>
    /// An object recognizer using PCA (Principle Components Analysis)
    /// </summary>
    [Serializable]
    public class EigenObjectRecognizer
    {
        private Image<Gray, Single>[] _eigenImages;
        private Image<Gray, Single> _avgImage; // ảnh trung bình 
        private Matrix<float>[] _eigenValues;//
        private string[] _labels;
        private double _eigenDistanceThreshold;

        /// <summary>
        /// Get the eigen vectors that form the eigen space
        /// lấy các vector riêng tạo nên không gian riêng 
        /// </summary>
        /// <remarks>The set method is primary used for deserialization, do not attemps to set it unless you know what you are doing</remarks>
        /// Phương thức thiết lập được sử dụng chính để deserialization, không attemps để thiết lập nó, trừ khi bạn biết những gì bạn đang làm
        public Image<Gray, Single>[] EigenImages
        {
            get { return _eigenImages; }
            set { _eigenImages = value; }
        }

        /// <summary>
        /// Get or set the labels for the corresponding training image
        /// Lấy hoặc đặt nhãn cho hình ảnh đào tạo tương ứng

        /// </summary>
        public String[] Labels
        {
            get { return _labels; }
            set { _labels = value; }
        }

        /// <summary>
        /// Get or set the eigen distance threshold.
        /// Lấy hoặc thiết lập ngưỡng khoảng eigen
        /// The smaller the number, the more likely an examined image will be treated as unrecognized object. 
        /// Số càng nhỏ, hình ảnh được kiểm tra sẽ được xem như là đối tượng không được công nhận
        /// Set it to a huge number (e.g. 5000) and the recognizer will always treated the examined image as one of the known object.
        ///  Đặt nó vào một số lớn (ví dụ như 5000) và bộ nhận dạng sẽ luôn coi hình ảnh được kiểm tra là một trong những đối tượng đã biết.
        /// </summary>
        public double EigenDistanceThreshold
        {
            get { return _eigenDistanceThreshold; }
            set { _eigenDistanceThreshold = value; }
        }

        /// <summary>
        /// Get the average Image. 
        /// Nhận hình ảnh trung bình.
        /// </summary>
        /// <remarks>The set method is primary used for deserialization, do not attemps to set it unless you know what you are doing</remarks>
        /// Phương pháp thiết lập là chính được sử dụng để deserialization, không attemps để thiết lập nó, trừ khi bạn biết những gì bạn đang làm
        public Image<Gray, Single> AverageImage
        {
            get { return _avgImage; }
            set { _avgImage = value; }
        }

        /// <summary>
        /// Get the eigen values of each of the training image
        /// Lấy giá trị eigen của mỗi hình đào tạo
        /// </summary>
        /// <remarks>The set method is primary used for deserialization, do not attemps to set it unless you know what you are doing</remarks>
        public Matrix<float>[] EigenValues
        {
            get { return _eigenValues; }
            set { _eigenValues = value; }
        }

        public Image<Gray, float> AvgImage { get { return _avgImage; } set { _avgImage = value;} }

        private EigenObjectRecognizer()// hàm khởi tạo mặt định
        {
        }


        /// <summary>
        /// Create an object recognizer using the specific tranning data and parameters, it will always return the most similar object
        /// Tạo một bộ nhận dạng đối tượng bằng cách sử dụng dữ liệu và các tham số chuyển dữ liệu cụ thể, nó sẽ luôn trả lại đối tượng tương tự nhất
        /// </summary>
        /// <param name="images">The images used for training, each of them should be the same size. It's recommended the images are histogram normalized</param>
        ///  Các hình ảnh được sử dụng cho đào tạo, mỗi người trong số họ phải có cùng kích cỡ. Đó là đề nghị các hình ảnh được histogram bình thường
        /// <param name="termCrit">The criteria for recognizer training</param>
        /// Các tiêu chuẩn cho đào tạo nhận dạng
        public EigenObjectRecognizer(Image<Gray, Byte>[] images, ref MCvTermCriteria termCrit)
           : this(images, GenerateLabels(images.Length), ref termCrit)
        {
        }

        private static String[] GenerateLabels(int size)
        {
            String[] labels = new string[size];
            for (int i = 0; i < size; i++)
                labels[i] = i.ToString();
            return labels;
        }

        /// <summary>
        /// Create an object recognizer using the specific tranning data and parameters, it will always return the most similar object
        ///Tạo một bộ nhận dạng đối tượng bằng cách sử dụng dữ liệu và các tham số chuyển dữ liệu cụ thể, nó sẽ trả về đối tượng tương tự nhất
        /// </summary>
        /// <param name="images">The images used for training, each of them should be the same size. It's recommended the images are histogram normalized</param>
        ///         ///  Các hình ảnh được sử dụng cho đào tạo, mỗi người trong số họ phải có cùng kích cỡ. Đó là đề nghị các hình ảnh được histogram bình thường

        /// <param name="labels">The labels corresponding to the images</param>
        /// Các nhãn tương ứng với hình ảnh
        /// <param name="termCrit">The criteria for recognizer training</param>
        /// Các tiêu chuẩn cho đào tạo nhận dạng
        public EigenObjectRecognizer(Image<Gray, Byte>[] images, String[] labels, ref MCvTermCriteria termCrit)
           : this(images, labels, 0, ref termCrit)
        {
        }

        /// <summary>
        /// Create an object recognizer using the specific tranning data and parameters
        /// Tạo một bộ nhận dạng đối tượng bằng cách sử dụng dữ liệu và các tham số chuyển dữ liệu cụ thể

        /// </summary>
        /// <param name="images">The images used for training, each of them should be the same size. It's recommended the images are histogram normalized</param>
        /// Các hình ảnh được sử dụng cho đào tạo, mỗi người trong số họ phải có cùng kích cỡ. Đó là đề nghị các hình ảnh được histogram bình thường

        /// <param name="labels">The labels corresponding to the images</param>
        /// Các nhãn tương ứng với hình ảnh
        /// <param name="eigenDistanceThreshold">
        /// The eigen distance threshold, (0, ~1000].
        /// Ngưỡng khoảng cách riêng, (0, ~ 1000).
        /// The smaller the number, the more likely an examined image will be treated as unrecognized object.
        /// Số càng nhỏ, hình ảnh được kiểm tra sẽ được xem như là đối tượng không được công nhận.
        /// If the threshold is &lt; 0, the recognizer will always treated the examined image as one of the known object.
        /// Nếu ngưỡng là & lt; 0, bộ nhận dạng sẽ luôn xử lý hình ảnh được kiểm tra như là một trong những đối tượng đã biết.
        /// </param>
        /// <param name="termCrit">The criteria for recognizer training</param>
        public EigenObjectRecognizer(Image<Gray, Byte>[] images, String[] labels, double eigenDistanceThreshold, ref MCvTermCriteria termCrit)
        {
            Debug.Assert(images.Length == labels.Length, "The number of images should equals the number of labels");// số lượng ảnh nên bằng số lượng nhãn
            Debug.Assert(eigenDistanceThreshold >= 0.0, "Eigen-distance threshold should always >= 0.0");

            CalcEigenObjects(images, ref termCrit, out _eigenImages, out _avgImage);

            /*
            _avgImage.SerializationCompressionRatio = 9;

            foreach (Image<Gray, Single> img in _eigenImages)
                //Set the compression ration to best compression. The serialized object can therefore save spaces
                img.SerializationCompressionRatio = 9;
            */

            _eigenValues = Array.ConvertAll<Image<Gray, Byte>, Matrix<float>>(images,
                delegate (Image<Gray, Byte> img)
                {
                    return new Matrix<float>(EigenDecomposite(img, _eigenImages, _avgImage));
                });

            _labels = labels;

            _eigenDistanceThreshold = eigenDistanceThreshold;
        }

        #region static methods
        /// <summary>
        /// Caculate the eigen images for the specific traning image
        /// tính toán các hình ảnh đào tạo  cụ thể
        /// </summary>
        /// <param name="trainingImages">The images used for training </param>
        /// // hình ảnh sử dụng để training 
        /// <param name="termCrit">The criteria for tranning</param>
        /// // các tiêu chí để trainning
        /// <param name="eigenImages">The resulting eigen images</param>
        /// // kết quả eigen 
        /// <param name="avg">The resulting average image</param>
        /// kết quả ảnh trung bình 
        public static void CalcEigenObjects(Image<Gray, Byte>[] trainingImages, ref MCvTermCriteria termCrit, out Image<Gray, Single>[] eigenImages, out Image<Gray, Single> avg)
        {
            int width = trainingImages[0].Width;// chiều rộng của ảnh training
            int height = trainingImages[0].Height;// chiều cao của ảnh training 

            IntPtr[] inObjs = Array.ConvertAll<Image<Gray, Byte>, IntPtr>(trainingImages, delegate (Image<Gray, Byte> img) { return img.Ptr; });

            if (termCrit.max_iter <= 0 || termCrit.max_iter > trainingImages.Length)
                termCrit.max_iter = trainingImages.Length;

            int maxEigenObjs = termCrit.max_iter;

            #region initialize eigen images
            eigenImages = new Image<Gray, float>[maxEigenObjs];
            for (int i = 0; i < eigenImages.Length; i++)
                eigenImages[i] = new Image<Gray, float>(width, height);
            IntPtr[] eigObjs = Array.ConvertAll<Image<Gray, Single>, IntPtr>(eigenImages, delegate (Image<Gray, Single> img) { return img.Ptr; });
            #endregion

            avg = new Image<Gray, Single>(width, height);

            CvInvoke.cvCalcEigenObjects(inObjs, ref termCrit, eigObjs, null, avg.Ptr);
        }

        /// <summary>
        /// Decompose the image as eigen values, using the specific eigen vectors
        /// Phân hủy hình ảnh dưới dạng các giá trị eigen, sử dụng vector đặc trưng riêng
        /// </summary>
        /// <param name="src">The image to be decomposed</param>
        /// hình ảnh bị phân hủy
        /// <param name="eigenImages">The eigen images</param>
        /// <param name="avg">The average images</param>
        /// ảnh trung bình 
        /// <returns>Eigen values of the decomposed image</returns>
        /// Giá trị Eigen của hình ảnh bị phân hủy

        public static float[] EigenDecomposite(Image<Gray, Byte> src, Image<Gray, Single>[] eigenImages, Image<Gray, Single> avg)
        {
            return CvInvoke.cvEigenDecomposite(
                src.Ptr,
                Array.ConvertAll<Image<Gray, Single>, IntPtr>(eigenImages, delegate (Image<Gray, Single> img) { return img.Ptr; }),
                avg.Ptr);
        }
        #endregion

        /// <summary>
        /// Given the eigen value, reconstruct the projected image
        /// Với giá trị eigen, tạo lại hình ảnh dự kiến

        /// </summary>
        /// <param name="eigenValue">The eigen values</param>
        /// giá trị eigen
        /// <returns>The projected image</returns>
        /// hình ảnh dự kiến 
        public Image<Gray, Byte> EigenProjection(float[] eigenValue)
        {
            Image<Gray, Byte> res = new Image<Gray, byte>(_avgImage.Width, _avgImage.Height);
            CvInvoke.cvEigenProjection(
                Array.ConvertAll<Image<Gray, Single>, IntPtr>(_eigenImages, delegate (Image<Gray, Single> img) { return img.Ptr; }),
                eigenValue,
                _avgImage.Ptr,
                res.Ptr);
            return res;
        }

        /// <summary>
        /// Get the Euclidean eigen-distance between <paramref name="image"/> and every other image in the database
        ///  Lấy eigenlidean eigen-khoảng cách giữa<paramref name = "image" /> và mọi hình ảnh khác trong cơ sở dữ liệu
        /// </summary>
        /// <param name="image">The image to be compared from the training images</param>
        ///  Hình ảnh được so sánh từ hình ảnh đào tạo
        /// <returns>An array of eigen distance from every image in the training images</returns>
        /// Một mảng khoảng cách eigen từ mọi hình ảnh trong hình đào tạo

        public float[] GetEigenDistances(Image<Gray, Byte> image)
        {
            using (Matrix<float> eigenValue = new Matrix<float>(EigenDecomposite(image, _eigenImages, _avgImage)))
                return Array.ConvertAll<Matrix<float>, float>(_eigenValues,
                    delegate (Matrix<float> eigenValueI)
                    {
                        return (float)CvInvoke.cvNorm(eigenValue.Ptr, eigenValueI.Ptr, Emgu.CV.CvEnum.NORM_TYPE.CV_L2, IntPtr.Zero);
                    });
        }

        /// <summary>
        /// Given the <paramref name="image"/> to be examined, find in the database the most similar object, return the index and the eigen distance
        /// Cho <paramref name = "image" /> được kiểm tra, tìm trong cơ sở dữ liệu đối tượng tương tự nhất, trả lại chỉ số và khoảng cách eigen
        /// </summary>
        /// <param name="image">The image to be searched from the database</param>
        /// Hình ảnh được tìm kiếm từ cơ sở dữ liệu
        /// <param name="index">The index of the most similar object</param>
        /// Chỉ số của đối tượng tương tự nhất
        /// <param name="eigenDistance">The eigen distance of the most similar object</param>
        /// Khoảng cách eigen của vật tương tự nhất

        /// <param name="label">The label of the specific image</param>
        /// Nhãn của hình ảnh cụ thể
        public void FindMostSimilarObject(Image<Gray, Byte> image, out int index, out float eigenDistance, out String label)
        {
            float[] dist = GetEigenDistances(image);

            index = 0;
            eigenDistance = dist[0];
            for (int i = 1; i < dist.Length; i++)
            {
                if (dist[i] < eigenDistance)
                {
                    index = i;
                    eigenDistance = dist[i];
                }
            }
            label = Labels[index];
        }

        /// <summary>
        /// Try to recognize the image and return its label
        /// Cố gắng nhận ra hình ảnh và trả lại nhãn của nó
        /// </summary>
        /// <param name="image">The image to be recognized</param>
        /// hình ảnh được công nhận
        /// <returns>
        /// String.Empty, if not recognized;// trả về string rỗng nếu không được công nhận
        /// Label of the corresponding image, otherwise
        /// Nhãn của hình ảnh tương ứng, nếu không
        /// </returns>
        public String Recognize(Image<Gray, Byte> image)
        {
            int index;
            float eigenDistance;
            String label;
            FindMostSimilarObject(image, out index, out eigenDistance, out label);

            return (_eigenDistanceThreshold <= 0 || eigenDistance < _eigenDistanceThreshold) ? _labels[index] : String.Empty;
        }
    }
}
