package com.iamchrisep.qrcodetool;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.media.Image;

import com.google.zxing.BarcodeFormat;
import com.google.zxing.BinaryBitmap;
import com.google.zxing.ChecksumException;
import com.google.zxing.DecodeHintType;
import com.google.zxing.EncodeHintType;
import com.google.zxing.FormatException;
import com.google.zxing.LuminanceSource;
import com.google.zxing.MultiFormatReader;
import com.google.zxing.MultiFormatWriter;
import com.google.zxing.NotFoundException;
import com.google.zxing.PlanarYUVLuminanceSource;
import com.google.zxing.RGBLuminanceSource;
import com.google.zxing.Reader;
import com.google.zxing.Result;
import com.google.zxing.WriterException;
import com.google.zxing.common.BitMatrix;
import com.google.zxing.common.HybridBinarizer;
import com.google.zxing.qrcode.QRCodeReader;

import java.nio.ByteBuffer;
import java.util.EnumMap;
import java.util.Map;

import static android.graphics.Color.BLACK;
import static android.graphics.Color.WHITE;


public class QRDecoder {
    private static boolean inProcess = false;
    public static Result DecodeImage(Image image) {

        if (inProcess) return null;

        inProcess = true;
        Result result = null;
        try {
            Image.Plane[] planes = image.getPlanes();
            if (planes == null) return null;
            if (planes.length >= 1 && planes[0] == null) return null;
            ByteBuffer byteBuffer = planes[0].getBuffer();
            byte[] data = new byte[byteBuffer.capacity()];
            byteBuffer.get(data);

//        int[] intArray = new int[bitmap.getWidth()*bitmap.getHeight()];
//        //copy pixel data from the Bitmap into the 'intArray' array
//        bitmap.getPixels(intArray, 0, bitmap.getWidth(), 0, 0, bitmap.getWidth(), bitmap.getHeight());
            int imageWidth = 0, imageHeight, left, top, width, height;
            imageWidth = image.getWidth();
            imageHeight = image.getHeight();
            left = imageWidth / 4;//(imageWidth - ScanQRCode.mRect.width()) / 2;
            top = imageHeight / 4;//(imageHeight - ScanQRCode.mRect.height()) / 2;
            width = imageWidth / 2;//ScanQRCode.mRect.width();
            height = imageHeight / 2;//ScanQRCode.mRect.height();

            PlanarYUVLuminanceSource source =
                    new PlanarYUVLuminanceSource(data, imageWidth, imageHeight,
                            left, top, width, height, false);

//        LuminanceSource source = new RGBLuminanceSource(image.getWidth(), image.getHeight(), data);
            BinaryBitmap binaryBitmap = new BinaryBitmap(new HybridBinarizer(source));

            Reader reader = new QRCodeReader();// MultiFormatReader();// use this otherwise ChecksumException
            try {
                result = reader.decode(binaryBitmap);

                //byte[] rawBytes = result.getRawBytes();
                //BarcodeFormat format = result.getBarcodeFormat();
                //ResultPoint[] points = result.getResultPoints();
            } catch (NotFoundException | ChecksumException | FormatException e) {
                e.printStackTrace();
            }
        } finally {
            inProcess = false;
        }

        return result;

//        MultiFormatReader reader = new MultiFormatReader();
//        try {
//            reader.decode(bitmap);
//        } catch (NotFoundException e) {
//            e.printStackTrace();
//        }

//        String contentsToEncode = contents;
//        if (contentsToEncode == null) {
//            return null;
//        }
//        Map<EncodeHintType, Object> hints = null;
//        String encoding = "UTF-8";//guessAppropriateEncoding(contentsToEncode);
//        if (encoding != null) {
//            hints = new EnumMap<>(EncodeHintType.class);
//            hints.put(EncodeHintType.CHARACTER_SET, encoding);
//        }
//        MultiFormatWriter writer = new MultiFormatWriter();
//        BitMatrix result;
//        try {
//            result = writer.encode(contentsToEncode, format, img_width, img_height, hints);
//        } catch (IllegalArgumentException iae) {
//            // Unsupported format
//            return null;
//        }
//        int width = result.getWidth();
//        int height = result.getHeight();
//        int[] pixels = new int[width * height];
//        for (int y = 0; y < height; y++) {
//            int offset = y * width;
//            for (int x = 0; x < width; x++) {
//                pixels[offset + x] = result.get(x, y) ? BLACK : WHITE;
//            }
//        }
//
//        Bitmap bitmap = Bitmap.createBitmap(width, height, Bitmap.Config.RGB_565);
//        bitmap.setPixels(pixels, 0, width, 0, 0, width, height);
//        return bitmap;
    }
}
