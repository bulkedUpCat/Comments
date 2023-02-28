import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { CreateCommentModel } from 'src/app/models/comment';

@Component({
  selector: 'comment-form',
  templateUrl: './comment-form.component.html',
  styleUrls: ['./comment-form.component.scss']
})
export class CommentFormComponent implements OnInit {
  commentForm!: UntypedFormGroup;
  editorConfig = {
    toolbar: [
      ['bold','italic','code']
    ]
  }

  @Output() handleSubmit = new EventEmitter<string>();
  @Output() handleCancel = new EventEmitter<void>();

  constructor(private fb: UntypedFormBuilder) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.commentForm = this.fb.group({
      text: [null, [Validators.required]]
    })
  }

  onSubmit(): void{
    this.handleSubmit.emit(this.commentForm.value.text);
    this.commentForm.reset();
  }

  onCancel(): void{
    this.handleCancel.emit();
    this.commentForm.reset();
  }

  onEditorContentChange(event: any){
    // if (event.editor.getLength() > 10){
    //   console.log('too long');
    //   event.editor.deleteText(10, event.editor.getLength());
    // }
  }
}
