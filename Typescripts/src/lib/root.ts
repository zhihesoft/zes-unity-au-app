import { container, singleton } from "tsyringe";
import { Bind, FadeService, I18nService, OnInit } from "zes-unity-jslib";
import { getLogger } from "zes-unity-jslib/dist/lib/logger";

@singleton()
export class Root implements OnInit {

    @Bind("#fade")
    fadeImage!: CS.UnityEngine.CanvasGroup
    @Bind("#label")
    label!: CS.TMPro.TMP_Text;

    async zesOnInit() {
        logger.info("root init");
        const i18n_svc = container.resolve(I18nService);
        const language = CS.Au.App.config.appLanguage;
        const languageBundle = CS.Au.App.config.bundleLanguage;
        await i18n_svc.load(language, `${languageBundle}/i18n-${language}.json`);
        const fade = container.resolve(FadeService);
        container.register(FadeService.fadeLayer, { useValue: this.fadeImage });
        fade.in();
    }
}

const logger = getLogger(Root.name);

