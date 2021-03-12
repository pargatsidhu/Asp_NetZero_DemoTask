import { DemoTaskTemplatePage } from './app.po';

describe('DemoTask App', function() {
  let page: DemoTaskTemplatePage;

  beforeEach(() => {
    page = new DemoTaskTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
