import { UnityEngine } from "csharp";
import { container, singleton } from "tsyringe";
import { Bind, FadeService, OnInit } from "zes-unity-jslib";

@singleton()
export class Root implements OnInit {

    @Bind("layers/fade/background")
    fadeImage!: UnityEngine.UI.Image;

    zesOnInit(): void {
        console.log("root init");
        const fade = container.resolve(FadeService);
        fade.speed = 1;
        fade.setFadeImage(this.fadeImage);
        fade.in();
    }

}