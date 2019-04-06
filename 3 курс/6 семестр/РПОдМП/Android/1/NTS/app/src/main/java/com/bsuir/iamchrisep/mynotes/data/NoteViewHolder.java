package com.bsuir.iamchrisep.mynotes.data;

import android.support.v7.widget.RecyclerView;
import android.text.SpannableString;
import android.text.style.StrikethroughSpan;
import android.view.View;
import android.widget.CheckBox;
import android.widget.TextView;

import com.bsuir.iamchrisep.mynotes.R;

/**
 * A ViewHolder for the NotesAdapter; used for linking each row in the notes list
 * to a view for display
 */
public class NoteViewHolder extends RecyclerView.ViewHolder {
    /**
     * The containing view
     */
    private final View mView;

    /**
     * The ID field
     */
    private final TextView mIdView;

    /**
     * The Title field
     */
    private final TextView mTitleView;

    /**
     * The CheckBox field
     */
    private final CheckBox mCheckBox;

    /**
     * The Note model that this view represents
     */
    private Note mItem;

    /**
     * initialize the viewholder with a specific view
     * @param view the view to link the data to.
     */
    public NoteViewHolder(View view) {
        super(view);
        mView = view;

        mIdView = (TextView) view.findViewById(R.id.list_id);
        mTitleView = (TextView) view.findViewById(R.id.list_title);
        mCheckBox = (CheckBox) view.findViewById(R.id.check_box);
    }

    @Override
    public String toString() {
        return super.toString() + " '" + mIdView.getText() + "'";
    }

    /**
     * Obtain a reference to the containing view
     * @return a View object
     */
    public View getView() {
        return mView;
    }

    /**
     * Obtain a reference to the data for this view
     * @return a Note object
     */
    public Note getNote() {
        return mItem;
    }

    /**
     * Set the data for this view.  Also adjusts the UI of the containing view
     * @param note The data
     */
    public void setNote(Note note) {
        mItem = note;
        if (note.getContent().length() <= 15) {
            mIdView.setText(note.getContent() + "\nLast Update: " + note.getUpdated().toString("yyyy-MM-dd HH:mm:ss"));
        } else {
            mIdView.setText(note.getContent().substring(0, 15) + "...\nLast Update: " + note.getUpdated().toString("yyyy-MM-dd HH:mm:ss"));
        }

        SpannableString title = new SpannableString(mItem.getTitle());
        if (mItem.getChecked()) {
            title.setSpan(new StrikethroughSpan(), 0, title.length(), 0);
        }
        mTitleView.setText(title);

        mCheckBox.setChecked(note.getChecked());
    }

    public CheckBox getCheckBox() { return mCheckBox; }
}
