export interface UserModel {
  userId: number;
  roleId: number;
  fullName: string;
  email: string;
  username: string;
  password: string;
  security_question: string;
  security_answer: string;
  activatedOn: string;
  isLocked: string;
  isArchived: string;
}
