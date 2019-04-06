/*
 * Copyright (C) The Android Open Source Project
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
package com.bsuir.iamchrisep;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.graphics.drawable.Drawable;
import android.support.annotation.NonNull;
import android.widget.ToggleButton;

import com.bsuir.iamchrisep.facefilters.camera.GraphicOverlay;
import com.google.android.gms.vision.face.Face;

/**
 * Graphic instance for rendering face position, orientation, and landmarks within an associated
 * graphic overlay view.
 */
class FaceGraphic extends GraphicOverlay.Graphic {
    private static final float FACE_POSITION_RADIUS = 10.0f;
    private static final float ID_TEXT_SIZE = 40.0f;
    private static final float ID_Y_OFFSET = 50.0f;
    private static final float ID_X_OFFSET = -50.0f;
    private static final float BOX_STROKE_WIDTH = 5.0f;

    private static final int COLOR_CHOICES[] = {
        Color.BLUE,
        Color.CYAN,
        Color.GREEN,
        Color.MAGENTA,
        Color.RED,
        Color.WHITE,
        Color.YELLOW
    };

    private boolean mIsFrontFacing;

    private static int mCurrentColorIndex = 0;

//    private Paint mFacePositionPaint;
//    private Paint mIdPaint;
//    private Paint mBoxPaint;

    private Paint mImagePaint;
    private Bitmap mImageBitmap;
    private Drawable mImageList;

    private volatile Face mFace;
//    private int mFaceId;
//    private float mFaceHappiness;

    Context mContext;
    ToggleButton mToggleButton;
    public Boolean toggleIsChecked = false;

    FaceGraphic(GraphicOverlay overlay, @NonNull Context context, boolean isFrontFacing) {
        super(overlay);

//        mCurrentColorIndex = (mCurrentColorIndex + 1) % COLOR_CHOICES.length;
//        final int selectedColor = COLOR_CHOICES[mCurrentColorIndex];

//        mFacePositionPaint = new Paint();
//        mFacePositionPaint.setColor(selectedColor);

//        mIdPaint = new Paint();
//        mIdPaint.setColor(selectedColor);
//        mIdPaint.setTextSize(ID_TEXT_SIZE);

//        mBoxPaint = new Paint();
//        mBoxPaint.setColor(selectedColor);
//        mBoxPaint.setStyle(Paint.Style.STROKE);
//        mBoxPaint.setStrokeWidth(BOX_STROKE_WIDTH);

        this.mIsFrontFacing = isFrontFacing;

        mImagePaint = new Paint();

        mToggleButton = MainActivity.mToggleButton;
        toggleIsChecked = mToggleButton.isChecked();
        if (toggleIsChecked) {
            mImageBitmap = BitmapFactory.decodeResource(context.getResources(), R.drawable.a);
        } else {
            mImageBitmap = BitmapFactory.decodeResource(context.getResources(), R.drawable.d);
        }

//        mImageList = context.getResources().getDrawable(R.drawable.btn_toggle, null);
//        Log.d("BITMAP", mImageList.toString());
//        System.console().printf(mImageList.toString());
//        mImageBitmap = ((BitmapDrawable) mImageList).getBitmap();

        mContext = context;
    }

    void setId(int id) {
//        int mFaceId = id;
    }


    /**
     * Updates the face instance from the detection of the most recent frame.  Invalidates the
     * relevant portions of the overlay to trigger a redraw.
     */
    void updateFace(Face face) {
        mFace = face;
        postInvalidate();
    }

    /**
     * Draws the face annotations for position on the supplied canvas.
     */
    @Override
    public void draw(Canvas canvas) {
        Face face = mFace;
        if (face == null) {
            return;
        }
        Integer scaleImg = 1;

//        Bitmap stateImage = ((BitmapDrawable) mImageList.getCurrent()).getBitmap();
//        Log.d("BITMAP", stateImage.toString());
//        Log.d("BITMAP", String.valueOf(stateImage.getGenerationId()));

        toggleIsChecked = mToggleButton.isChecked();
        if (toggleIsChecked) {
            mImageBitmap = BitmapFactory.decodeResource(mContext.getResources(), R.drawable.doom);
            scaleImg = 4;
        } else {
            mImageBitmap = BitmapFactory.decodeResource(mContext.getResources(), R.drawable.hat);
            scaleImg = 5;
        }
        if (mImageBitmap == null) {
            return;
        }

        // Draws a circle at the position of the detected face, with the face's track id below.
        float x = translateX(face.getPosition().x + face.getWidth() / 2);
        float y = translateY(face.getPosition().y + face.getHeight() / 2);
//        canvas.drawCircle(x, y, FACE_POSITION_RADIUS, mFacePositionPaint);
//        canvas.drawText("id: " + mFaceId, x + ID_X_OFFSET, y + ID_Y_OFFSET, mIdPaint);
//        canvas.drawText("happiness: " + String.format("%.2f", face.getIsSmilingProbability()), x - ID_X_OFFSET, y - ID_Y_OFFSET, mIdPaint);
//        canvas.drawText("right eye: " + String.format("%.2f", face.getIsRightEyeOpenProbability()), x + ID_X_OFFSET * 2, y + ID_Y_OFFSET * 2, mIdPaint);
//        canvas.drawText("left eye: " + String.format("%.2f", face.getIsLeftEyeOpenProbability()), x - ID_X_OFFSET*2, y - ID_Y_OFFSET*2, mIdPaint);

        // Draws a bounding box around the face.
        float xOffset = scaleX(face.getWidth() / 2.0f);
        float yOffset = scaleY(face.getHeight() / 2.0f);
        float left = x - xOffset;
        float top = y - yOffset;
        float right = x + xOffset;
        float bottom = y + yOffset;
//        canvas.drawRect(left, top, right, bottom, mBoxPaint);

        Matrix matrix = new Matrix();
        matrix.postScale(scaleImg*face.getWidth()/mImageBitmap.getWidth(), scaleImg*face.getWidth()/mImageBitmap.getWidth());
        Bitmap tmpImage = Bitmap.createBitmap(mImageBitmap, 0,0,mImageBitmap.getWidth(),mImageBitmap.getHeight(), matrix,true);

//        matrix.postScale(face.getWidth()/mImageList.getIntrinsicWidth(), face.getWidth()/mImageList.getIntrinsicWidth());
//        Bitmap tmpImage = Bitmap.createBitmap(((BitmapDrawable) mImageList.getCurrent()).getBitmap(), 0, 0, mImageList.getIntrinsicWidth(), mImageList.getIntrinsicHeight(), matrix, true);

//        matrix.postScale(face.getWidth()/stateImage.getWidth(), face.getWidth()/stateImage.getWidth());
//        Bitmap tmpImage = Bitmap.createBitmap(stateImage, 0,0,stateImage.getWidth(),stateImage.getHeight(), matrix,true);

        matrix.reset();
        if (toggleIsChecked) {
            matrix.postTranslate(x - tmpImage.getWidth() / 2, top + 50);
        } else {
            matrix.postTranslate(x - tmpImage.getWidth() / 2, top - tmpImage.getHeight() / 2 + 20);
        }
//        matrix.postTranslate(x - tmpImage.getWidth()/2, top);
        float angle =((mIsFrontFacing?1:-1)*face.getEulerZ());
        matrix.postRotate(angle, x, y);
//        canvas.drawBitmap(mImageBitmap, x - mImageBitmap.getWidth()/2, top, mImagePaint);
        canvas.drawBitmap(tmpImage, matrix, mImagePaint);
    }
}
