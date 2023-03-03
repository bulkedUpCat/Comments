import { Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { CommentSubmitModel } from 'src/app/models/comment';
import { BlobService } from 'src/app/services/blob.service';

@Component({
  selector: 'comment-form',
  templateUrl: './comment-form.component.html',
  styleUrls: ['./comment-form.component.scss']
})
export class CommentFormComponent implements OnInit {
  commentForm!: UntypedFormGroup;
  editorConfig = {
    toolbar: [
      ['bold','italic','code', 'link']
    ]
  };
  captcha: string = '';
  formData: FormData = new FormData();
  error: boolean = false;
  errorMessage: string = '';

  @Input() hasCancelButton: boolean = false;
  @Input() defaultText: string = '';
  @Output() handleSubmit: EventEmitter<CommentSubmitModel> = new EventEmitter<CommentSubmitModel>();
  @Output() handleCancel: EventEmitter<void> = new EventEmitter<void>();

  @ViewChild('fileInput') fileInput!: ElementRef;

  constructor(
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.commentForm = this.fb.group({
      text: [null, [Validators.required, Validators.maxLength(10000)]]
    })
  }

  onSubmit(): void{
    if (this.commentForm.get('text')?.errors){
      this.error = true;
      this.errorMessage = 'Enter some text (max 10000 characters)';
      return;
    }

    this.handleSubmit.emit({text: this.commentForm.value.text, formData: this.formData});
    this.fileInput.nativeElement.value = "";
    this.commentForm.reset();
    this.error = false;
  }

  onCancel(): void{
    this.handleCancel.emit();
    this.commentForm.reset();
  }

  onEditorContentChange(event: any){

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

  // resizeImage(imageURL: any): Promise<any> {
  //   return new Promise((resolve) => {
  //     var image = new Image();
  //     image.onload = function () {
  //       var canvas = document.createElement('canvas');
  //       var ctx = canvas.getContext('2d');
  //       if (ctx != null) {
  //         ctx.drawImage(image, 0, 0, 640, 480);
  //       }
  //       var data = canvas.toBlob('sdf')
  //       resolve(data);
  //     };
  //     image.src = imageURL;
  //   });
  // }
}
