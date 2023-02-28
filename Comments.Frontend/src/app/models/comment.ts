export class CommentModel{
  id!: string;
  userName!: string;
  text!: string;
  createdAt!: Date;
  parentCommentId!: string;
  replies!: CommentModel[];
}

export class CreateCommentModel{
  text!: string;
  parentCommentId: string | undefined;
}

export class CurrentComment{
  id!: string;
  type!: CurrentCommentType;
}

export enum CurrentCommentType{
  reply,
  edit
}
