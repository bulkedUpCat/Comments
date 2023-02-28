import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { create } from 'domain';

@Component({
  selector: 'comment-form',
  templateUrl: './comment-form.component.html',
  styleUrls: ['./comment-form.component.scss']
})
export class CommentFormComponent implements OnInit {
  commentForm!: FormGroup;

  @Output() handleSubmit = new EventEmitter<string>();

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.createForm();
  }

  createForm(){
    this.commentForm = this.fb.group({
      text: [null, [Validators.required]]
    })
  }

  onSubmit(): void{
    const createCommentModel = this.commentForm.value;
    createCommentModel.userName = 'Bob';
    createCommentModel.email = 'bob@gmail.com';

    this.handleSubmit.emit(this.commentForm.value.text);
    this.commentForm.reset();
  }
}
