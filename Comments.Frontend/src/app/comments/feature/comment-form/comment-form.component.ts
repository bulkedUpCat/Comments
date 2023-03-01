import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';

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
  };
  captcha: string = '';
  formData: FormData = new FormData();
  error: boolean = false;
  errorMessage: string = '';

  @Input() hasCancelButton: boolean = false;
  @Output() handleSubmit: EventEmitter<string> = new EventEmitter<string>();
  @Output() handleCancel: EventEmitter<void> = new EventEmitter<void>();

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

  resolved(captchaResponse: string){
    this.captcha = captchaResponse;
    console.log(this.captcha);
  }

  onAttachFile(files: any){
    console.log(files[0]);
    if (files[0]){

      if (files[0].size > 100000 && files[0].type == 'text/plain'){
        this.error = true;
        this.errorMessage = 'The file is too big';
        return;
      }

      this.formData.append('file', files[0]);
    }
  }
}
